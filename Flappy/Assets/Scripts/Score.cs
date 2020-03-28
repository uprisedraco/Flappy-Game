using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    int score;
    private Text textScore;

    void Start()
    {
        score = 0;
        textScore = GetComponent<Text>();
        textScore.text = score.ToString();
    }

    public void Scored()
    {
        score++;
        textScore.text = score.ToString();
    }

    void Update()
    {
        
    }
}
