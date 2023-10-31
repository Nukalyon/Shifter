using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameMode gameMode{get; private set;}
    //Singleton
    public static GameManager instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            //Persistance du GameMode
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            GoToMainMenu();
        }
    }


    public void GoToMainMenu()
    {
        //Ordre dans File -> Build Settings
        //SceneManager.LoadScene(1);
        SceneManager.LoadScene("Main Menu");
    }

    public void ChangeGameMode(GameMode gm)
    {
        gameMode = gm;
    }

    internal void GoToScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
}

public enum GameMode
{
    Play,
    Pause
}