using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    [SerializeField]
    private float speed;

    private BoxCollider2D box;
    private float groundWidth;

    private float pipeWidth;


    void Start()
    {
        if(gameObject.CompareTag("Ground"))
        {
            box = GetComponent<BoxCollider2D>();
            groundWidth = box.size.x;
        }
        else if(gameObject.CompareTag("Column"))
        {
            pipeWidth = GameObject.FindGameObjectWithTag("Pipe").GetComponent<BoxCollider2D>().size.x;
        }
    }

    void Update()
    {
        if(GameManager.gameOver == false)
            transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);

        if (gameObject.CompareTag("Ground"))
        {
            if (transform.position.x <= -groundWidth)
            {
                transform.position = new Vector2(transform.position.x + 2 * groundWidth, transform.position.y);
            }
        }
        else if (gameObject.CompareTag("Column"))
        {
            if(transform.position.x < GameManager.bottomLeft.x - pipeWidth)
            {
                Destroy(gameObject);
            }
        }
    }
}
