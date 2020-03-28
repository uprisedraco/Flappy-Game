using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverAnim : MonoBehaviour
{
    [SerializeField]
    private GameObject medal;

    [SerializeField]
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnGameOverAnimEnds()
    {
        medal.SetActive(true);
        gameManager.DrawScore();
    }
}
