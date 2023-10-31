using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class MenuController : MonoBehaviour
{
    public static bool gameIsPaused = false;
    public GameObject pauseMenuUI; 
    
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
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Debug.Log("Scene restarted.");
    }

    public void Escape()
    {
        changeScene("PauseMenu"/*, LoadSceneMode.Single*/);
        
        //pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
        
        Debug.Log("Application paused.");
    }

    internal void Resume()
    {
        SceneManager.LoadScene("SampleScene"/*, LoadSceneMode.Single*/);

        //pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;

        Debug.Log("Application resumed.");
    }


}
