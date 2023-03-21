using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public enum DisplayMenu
    {
        None,
        MainMenu,
        PauseMenu,
        OptionsMenu
    }

    public static bool GameIsPaused = false;
    public GameObject menuUI;
    public GameObject pauseUI;
    public GameObject optionsUI;
    public GameObject miniMap;
    public Animator transition;
    public float transitionTime = 1f;

    public void Start()
    {
        this.gameObject.SetActive(true);
        Resume();
        if (SceneManager.GetActiveScene().buildIndex == 0)
            SetMenu(DisplayMenu.MainMenu);
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (optionsUI.activeSelf)
            {
                HideOptions();
            }
            else if (SceneManager.GetActiveScene().buildIndex != 0)
            {
                switch (GameIsPaused)
                {
                    case true:
                        Resume();
                        break;
                    case false:
                        Pause();
                        break;
                }
            }
        }
    }

    public void SetMenu(DisplayMenu menu)
    {
        optionsUI.SetActive(menu == DisplayMenu.OptionsMenu);
        menuUI.SetActive(menu == DisplayMenu.MainMenu);
        pauseUI.SetActive(menu == DisplayMenu.PauseMenu);
        miniMap.SetActive(menu == DisplayMenu.None);
    }

    public void ShowOptions()
    {
        SetMenu(DisplayMenu.OptionsMenu);
    }

    public void HideOptions()
    {
        SetMenu(GameIsPaused ? DisplayMenu.PauseMenu : DisplayMenu.MainMenu);
    }

    public void PlayGame()
    {
        SetMenu(DisplayMenu.None);
        StartCoroutine(LoadLevel(3));
    }

    public IEnumerator LoadLevel(int levelIndex)
    {
        yield return StartTransition();
        SceneManager.LoadScene(levelIndex);
    }

    public IEnumerator LoadLevel(string level)
    {
        yield return StartTransition();
        SceneManager.LoadScene(level);
    }

    public IEnumerator StartTransition()
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
    }

    public void Resume()
    {
        SetMenu(DisplayMenu.None);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void Pause()
    {
        SetMenu(DisplayMenu.PauseMenu);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void BackToLobby()
    {
        Resume();
        StartCoroutine(LoadLevel(0));
    }

    public void Quit()
    {
        Application.Quit();
    }
}