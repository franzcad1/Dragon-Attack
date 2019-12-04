using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    private bool gameOver, restart, win;
    
    [Header("UI Settings")]
    public Text winText;
    public Text winText2;
    public Text gameOverText;
    public Text restartText2;
    public Text restartText;
    public Text timetext;
    public GameObject panel;
    public RectTransform NewPos;
    public GameObject music;
    void Start()
    {
        Object.DontDestroyOnLoad(music.gameObject);
        gameOver = restart = false;
        win = false;
        
    }
    void Update()
    {
        if (restart)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // QUIT THE GAME
            Application.Quit();
        }

        if (gameOver)
        {
            restartText.gameObject.SetActive(true);
            restart = true;
        }

    }

    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        gameOver = true;
        timetext.gameObject.SetActive(false);

    }

    public void Win()
    {
        
        panel.gameObject.SetActive(true);
        winText.gameObject.SetActive(true);
        winText2.gameObject.SetActive(true);
        win = true;
        restart = true;
        restartText2.gameObject.SetActive(true);
        timetext.rectTransform.position = new Vector3(NewPos.position.x, NewPos.position.y, NewPos.position.z); 
    }

  
    
}
