using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class MenuController : MonoBehaviour
{   
    Canvas canvasMenu { get; set; }
    Canvas canvasGame { get; set; }
    public void Start()
    {
        canvasGame = GameObject.Find("Canvas Game").GetComponent<Canvas>();
        canvasMenu = GameObject.Find("Canvas Menu").GetComponent<Canvas>();

        canvasMenu.gameObject.SetActive(false);
        canvasGame.gameObject.SetActive(true);
    }
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
        SceneManager.LoadScene(1);
        Debug.Log("Scene restarted.");
    }

    public void Escape()
    {
        //changeScene("PauseMenu"/*, LoadSceneMode.Single*/);
        //gameIsPaused = true;

        canvasMenu.gameObject.SetActive(true);
        canvasGame.gameObject.SetActive(false);

        Time.timeScale = 0f;

        Debug.Log("Application paused.");
    }

    internal void Resume()
    {
        canvasMenu.gameObject.SetActive(false);
        canvasGame.gameObject.SetActive(true);

        Time.timeScale = 1f;

        Debug.Log("Application resumed.");
    }


}
