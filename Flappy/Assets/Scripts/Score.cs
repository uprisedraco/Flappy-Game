using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    int score;
    int highScore;
    private Text textScore;

    [SerializeField]
    private Text panelScore;

    [SerializeField]
    private Text panelHighScore;

    [SerializeField]
    private GameObject newImg;

    void Start()
    {
        score = 0;
        textScore = GetComponent<Text>();
        panelScore.text = score.ToString();
        textScore.text = score.ToString();

        highScore = PlayerPrefs.GetInt("highScore");
        panelHighScore.text = highScore.ToString();
    }

    public int GetScore()
    {
        return score;
    }

    public void Scored()
    {
        score++;
        textScore.text = score.ToString();
        //panelScore.text = score.ToString();

        if(score > highScore)
        {
            highScore = score;
            panelHighScore.text = highScore.ToString();
            PlayerPrefs.SetInt("highScore", highScore);
            newImg.SetActive(true);
        }
    }

    void Update()
    {
        
    }
}
