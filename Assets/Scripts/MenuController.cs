using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class MenuController : MonoBehaviour
{
    Canvas canvasGame; //{ get; set; }
    Canvas canvasMenu; //{ get; set; }
    public void Start()
    {
        canvasGame = GameObject.Find("Canvas Game").GetComponent<Canvas>();
        canvasMenu = GameObject.Find("Canvas Menu").GetComponent<Canvas>();

        canvasGame.gameObject.SetActive(true);
        canvasMenu.gameObject.SetActive(false);
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
        changeScene("World Scene");
        Debug.Log("Scene restarted.");
    }

    public void Escape()
    {
        //changeScene("PauseMenu"/*, LoadSceneMode.Single*/);
        //gameIsPaused = true;

        canvasGame.gameObject.SetActive(false);
        canvasMenu.gameObject.SetActive(true);

        Time.timeScale = 0f;

        Debug.Log("Application paused.");
    }

    public void Resume()
    {
        canvasGame.gameObject.SetActive(true);
        canvasMenu.gameObject.SetActive(false);

        Time.timeScale = 1f;

        Debug.Log("Application resumed.");
    }


}
