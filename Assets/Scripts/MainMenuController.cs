using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public void StartButton() 
    {
        SceneManager.LoadScene("MazeScene");
        Debug.Log("Start Button");
    }

    public void OptionsButton() 
    {
        Debug.Log("Options Menu");
    }

    public void QuitButton() 
    {
        Debug.Log("Application Quit");
        Application.Quit();
    }
}
