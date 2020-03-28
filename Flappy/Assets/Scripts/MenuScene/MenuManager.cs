using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField]
    private Animator blackFade;

    void Start()
    {
        GameManager.gameOver = false;
    }

    void Update()
    {
        
    }

    public void OnPlayButtonPressed()
    {
        //SceneManager.LoadScene("Game");
        blackFade.SetTrigger("fadeIn");
    }
}
