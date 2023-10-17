using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public void changeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        Debug.Log("Changed scene.");
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("Application closed.");
    }

    public void Escape()
    {
        Time.timeScale = 0;
        SceneManager.LoadScene("PauseMenu", LoadSceneMode.Single);
        Debug.Log("Application paused.");
    }

    internal void Resume()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
        Debug.Log("Application resumed.");
    }
}
