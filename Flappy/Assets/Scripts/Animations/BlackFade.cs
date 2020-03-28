using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BlackFade : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void OnBlackFadeFinished()
    {
        if(SceneManager.GetActiveScene().name == "Menu")
        {
            SceneManager.LoadScene("Game");
        }
        else if(SceneManager.GetActiveScene().name == "Game")
        {
            SceneManager.LoadScene("Menu");
        }
    }
}
