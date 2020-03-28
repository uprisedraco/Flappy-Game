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
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && GameManager.gameOver == false)
        {
            rb.velocity = Vector2.zero;
            rb.velocity = new Vector2(rb.velocity.x, speed);
        }

        BirdRotation();
    }

    void BirdRotation()
    {
        if (rb.velocity.y > 0)
        {
            if (angle <= maxAngle)
            {
                angle += 4;
            }
        }
        else if (rb.velocity.y < -1.3f)
        {
            if (angle >= minAngle)
            {
                angle -= 3;
            }
        }

        if(touchedGround == false)
            transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Column"))
        {
            score.Scored();
        }
        else if (collision.CompareTag("Pipe"))
        {
            gameManager.GameOver();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            if(GameManager.gameOver == false)
            {
                gameManager.GameOver();
                GameOver();
            }
            else
            {
                GameOver();
            }
        }
    }

    void GameOver()
    {
        touchedGround = true;
        anim.enabled = false;
        sr.sprite = birdDied;
        transform.rotation = Quaternion.Euler(0, 0, -90);
    }
}
