using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject menuUI;

    public void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex != 0)
        {
            Resume();
        }
    }

    public void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex != 0)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (GameIsPaused)
                {
                    Resume();
                }
                else
                {
                    Pause();
                }
            }
        }
    }

    public void PlayGame()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            SceneManager.LoadScene(1);
        }
        else
        {
            Resume();
        }
    }

    public void Resume()
    {
        menuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void Pause()
    {
        menuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void Quit()
    {
        Application.Quit();
    }
}
