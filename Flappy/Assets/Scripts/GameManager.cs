using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    public static Vector2 bottomLeft;

    public static bool gameOver;
    public static bool gameHasStarted;
    public static bool gameIsPaused;

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
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void OnMenuBtnPressed()
    {
        //SceneManager.LoadScene("Menu");
        blackFade.SetTrigger("fadeIn");
    }

    public void GameOver()
    {
        gameOver = true;
        score.SetActive(false);
        gameOverCanvas.SetActive(true);
        pauseBtn.SetActive(false);
    }
}
