using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    //TODO REFACTOR THIS AND USE THIS WITH UI MANAGER 
    private static bool _GameIsPaused;
    [SerializeField] GameObject _pauseMenuUI;
    [SerializeField] GameObject _optionsMenuUI;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (_GameIsPaused)
            {
                _optionsMenuUI.SetActive(false);
                _pauseMenuUI.SetActive(false);
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }


    private void Resume() 
    {
        _pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        _GameIsPaused = false;
    }

    private void Pause() 
    {
        _pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        _GameIsPaused = true;
    }

    public void ResumeButton() 
    {
        Debug.Log("ResumeButton Clicked");
        Resume();
    }
    
    public void OptionsButton() 
    {
        if (_pauseMenuUI.activeSelf == true && _GameIsPaused)
        {
            _pauseMenuUI.SetActive(false);
            _optionsMenuUI.SetActive(true);
        }
       
        Debug.Log("OptionsButton Clicked");
    }
    //TODO When you "re-load" scene with this piece of code it will cause your coin counter to broke 
    //You are assuming this is cause the value you assing in inspector is returnin null after you
    //Re-Load Scene you have to fix that 
    public void RestartButton() 
    {
        SceneManager.LoadScene("MazeScene");
        Time.timeScale = 1f;
        Debug.Log("Restart Button");
        
    }

    public void QuitButton() 
    {
        Debug.Log("QuitButton Clicked");
        Application.Quit();
    }
}
