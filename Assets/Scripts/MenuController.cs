using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class MenuController : MonoBehaviour
{
    public InputController InputController;
    public Health Health;
    public GameObject gameObjectGame;
    public GameObject gameObjectMenu;

    public static MenuController Singleton;
    public void Awake()
    {
        //gameObjectGame = GameObject.Find("Canvas Game").GetComponent<Canvas>();
        //gameObjectMenu = GameObject.Find("Canvas Menu").GetComponent<Canvas>();

        if (!Singleton)
        { 
            Singleton = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        if(gameObjectGame == null || gameObjectMenu == null)
        {
            Debug.LogError("Canvas components not found.");
        }
        else
        {
            gameObjectGame.SetActive(true);
            gameObjectMenu.SetActive(false);
        }

    }
    public void changeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        Debug.Log("Changed scene.");
    }

    public void OnLeaveButtonClick()
    {
        Application.Quit();
        Debug.Log("Application closed.");
    }
    public void OnRestartButtonClick()
    {
        Time.timeScale = 1f;

        InputController.ResetPosition();
        Health.RegenMaxHealth();

        gameObjectGame.SetActive(true);
        gameObjectMenu.SetActive(false);

        Debug.Log("Scene restarted.");
    }

    public void OnEscapeButtonClick()
    {
        gameObjectGame.SetActive(false);
        gameObjectMenu.SetActive(true);

        Time.timeScale = 0f;

        Debug.Log("Pause menu loaded (Game paused).");
    }

    public void OnResumeButtonClick()
    {
        gameObjectGame.SetActive(true);
        gameObjectMenu.SetActive(false);

        Time.timeScale = 1f;

        Debug.Log("Pause menu hidden (Game resumed).");
    }


}
