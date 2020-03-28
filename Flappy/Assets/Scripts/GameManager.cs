using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject gameOverCanvas;

    [SerializeField]
    private GameObject score;

    [SerializeField]
    private GameObject getReadyImg;

    [SerializeField]
    private GameObject pauseBtn;

    [SerializeField]
    private Animator blackFade;

    [SerializeField]
    private Text panelScore;

    public static Vector2 bottomLeft;

    public static bool gameOver;
    public static bool gameHasStarted;
    public static bool gameIsPaused;
    
    public static int gameScore;
    private int drawScore;

    private void Awake()
    {
        bottomLeft = Camera.main.ScreenToWorldPoint(new Vector2(0, 0));
    }

    void Start()
    {
        gameOver = false;
        gameHasStarted = false;
        gameIsPaused = false;
    }

    void Update()
    {
        
    }

    public void GameHasStarted()
    {
        gameHasStarted = true;
        score.SetActive(true);
        getReadyImg.SetActive(false);
        pauseBtn.SetActive(true);
    }

    public void OnOkBtnPressed()
    {
        AudioManager.audiomanager.Play("transition");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void OnMenuBtnPressed()
    {
        AudioManager.audiomanager.Play("transition");
        //SceneManager.LoadScene("Menu");
        blackFade.SetTrigger("fadeIn");
    }

    public void GameOver()
    {
        gameOver = true;
        gameScore = score.GetComponent<Score>().GetScore();
        score.SetActive(false);
        Invoke("ActivateGameOverCanvas", 1);
        pauseBtn.SetActive(false);
    }

    public void DrawScore()
    {
        if(drawScore <= gameScore)
        {
            panelScore.text = drawScore.ToString();
            drawScore++;
            Invoke("DrawScore", 0.05f);
        }
    }

    void ActivateGameOverCanvas()
    {
        gameOverCanvas.SetActive(true);
        AudioManager.audiomanager.Play("die");
    }
}
