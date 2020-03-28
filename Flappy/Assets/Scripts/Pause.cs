using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    private Image img;

    [SerializeField]
    private Sprite playSprite;

    [SerializeField]
    private Sprite pausedSprite;

    private void Start()
    {
        img = GetComponent<Image>();
    }

    public void OnPauseGame()
    {
        if(GameManager.gameIsPaused == false)
        {
            Time.timeScale = 0;
            img.sprite = playSprite;
            GameManager.gameIsPaused = true;
        }
        else
        {
            Time.timeScale = 1f;
            img.sprite = pausedSprite;
            GameManager.gameIsPaused = false;
        }
    }
}
