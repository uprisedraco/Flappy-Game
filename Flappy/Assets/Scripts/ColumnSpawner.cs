using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject column;

    [SerializeField]
    private float maxY;

    [SerializeField]
    private float minY;

    private float randY;

    [SerializeField]
    private float maxTime;
    private float timer;

    void Start()
    {
        InstantiateColumn();
    }

    void Update()
    {
        if(GameManager.gameOver == false)
        {
            timer += Time.deltaTime;

            if (timer >= maxTime)
            {
                InstantiateColumn();
                timer = 0;
            }
        } 
    }

    void InstantiateColumn()
    {
        randY = Random.Range(minY, maxY);
        GameObject newColumn = Instantiate(column);
        newColumn.transform.position = new Vector2(transform.position.x, randY);
    }
}
