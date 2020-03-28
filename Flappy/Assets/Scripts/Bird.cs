using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    [SerializeField]
    private Score score;

    [SerializeField]
    private GameManager gameManager;

    [SerializeField]
    private Sprite birdDied;

    [SerializeField]
    private ColumnSpawner columnSpawner;

    [SerializeField]
    private Animator birdParentAnim;

    [SerializeField]
    private Animator getReadyAnim;

    [SerializeField]
    private Animator hitEffect;

    [SerializeField]
    private Animator cameraAnim;

    private SpriteRenderer sr;

    private Rigidbody2D rb;

    private Animator anim;

    [SerializeField]
    private float speed;

    private int angle;
    private int maxAngle = 20;
    private int minAngle = -90;

    bool touchedGround;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();

        rb.gravityScale = 0;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && GameManager.gameOver == false && GameManager.gameIsPaused == false)
        {
            if(GameManager.gameHasStarted == false)
            {
                rb.gravityScale = 0.8f;
                birdParentAnim.enabled = false;
                Flap();
                getReadyAnim.SetTrigger("fadeOut");
            }
            else
            {
                Flap();
            }
        }

        BirdRotation();
    }

    public void OnGetReadyAnimFinished()
    {
        columnSpawner.InstantiateColumn();
        gameManager.GameHasStarted();
    }

    void Flap()
    {
        rb.velocity = Vector2.zero;
        rb.velocity = new Vector2(rb.velocity.x, speed);
        AudioManager.audiomanager.Play("flap");
    }

    void BirdRotation()
    {
        if (rb.velocity.y > 0)
        {
            rb.gravityScale = 0.8f;

            if (angle <= maxAngle)
            {
                angle += 4;
            }
        }
        else if (rb.velocity.y < 0)
        {
            rb.gravityScale = 0.7f;

            if (rb.velocity.y < -1.3f)
            {
                if (angle >= minAngle)
                {
                    angle -= 3;
                }
            }
        }

        if(touchedGround == false)
            transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(GameManager.gameOver == false)
        {
            if (collision.CompareTag("Column"))
            {
                AudioManager.audiomanager.Play("point");
                score.Scored();
            }
            else if (collision.CompareTag("Pipe"))
            {
                BirdDieEffect();
                gameManager.GameOver();
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            if(GameManager.gameOver == false)
            {
                BirdDieEffect();
                gameManager.GameOver();
                GameOver();
            }
            else
            {
                GameOver();
            }
        }
    }

    void BirdDieEffect()
    {
        AudioManager.audiomanager.Play("hit");
        hitEffect.SetTrigger("hit");
        cameraAnim.SetTrigger("shake");
    }

    void GameOver()
    {
        touchedGround = true;
        anim.enabled = false;
        sr.sprite = birdDied;
        transform.rotation = Quaternion.Euler(0, 0, -90);
    }
}
