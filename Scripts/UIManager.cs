using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject gameoverPanel;

    //public GameObject levelSelectPanel;

    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;

    public bool paused = false;
    
    void Start()
    {

    }
        
    public void showGameOverPanel(bool isShow)
    {
        if (gameoverPanel)
        {
            gameoverPanel.SetActive(isShow);
        }
    }

    public void ResumeButton()
    {
        paused = false;
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void PauseButton()
    {
        paused = true;
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void LevelButton()
    {
        SceneManager.LoadScene("LevelSelect");
    }

    public void MenuButton()
    {
        SceneManager.LoadScene("Menu");
    }

    public void QuitGameButton()
    {
        Application.Quit();
    }
}
