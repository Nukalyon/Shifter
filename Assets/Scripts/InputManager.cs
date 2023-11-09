using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InputManager : MonoBehaviour
{
    private enum SceneState
    {
        gameActive,
        gamePaused
    }

    private SceneState state = SceneState.gameActive;

    [Header("KeyCode Parameters")]
    [SerializeField] private KeyCode jumpKey = KeyCode.Space;
    [SerializeField] private KeyCode shootKey = KeyCode.Mouse0;
    [SerializeField] private KeyCode leftKey = KeyCode.A;
    [SerializeField] private KeyCode rightKey = KeyCode.D;
    [SerializeField] private KeyCode upKey = KeyCode.W;
    [SerializeField] private KeyCode pauseKey = KeyCode.Escape;

    [SerializeField] private int jumpForce = 5;
    /*
    [SerializeField] private KeyCode botKey = KeyCode.S; 
    [SerializeField] private string axisX = "player_X";
    [SerializeField] private string axisY = "player_Y";
    */
    [Header("Object References")]
    [SerializeField] private InputController player;
    [SerializeField] private FireingBehaviour projectile;
    [SerializeField] private Transform projectileFirePoint;



    public void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        Jump();
        Movement();
        Attack();
        ChangeScene();
    }

    public void ChangeScene()
    {
        if (Input.GetKeyDown(pauseKey) && state == SceneState.gameActive)
        {
            MenuController.Singleton.OnEscapeButtonClick();
            state = SceneState.gamePaused;
        }
        else if (Input.GetKeyDown(pauseKey) && state == SceneState.gamePaused)
        {
            MenuController.Singleton.OnResumeButtonClick();
            state = SceneState.gameActive;
        }
    }

    public void Jump()
    {
        if(Input.GetKeyDown(jumpKey) || Input.GetKeyDown(upKey))
        {
            //Jump!
            player.Jump(jumpForce);
        }
    }

    public void Movement()
    {
        if(Input.GetKey(rightKey))
        {
            player.Move(1);
            projectileFirePoint.transform.localScale = new Vector3(1, 0, 0);
        }
        else if (Input.GetKey(leftKey))
        {
            player.Move(-1);
            projectileFirePoint.transform.localScale = new Vector3(-1, 0, 0);
        }
        else
        {
            player.Move(0);
        }
        /*
        float dirX = Input.GetAxisRaw(axisX);
        float dirY = Input.GetAxisRaw(axisY);

        player.Movement(dirX, dirY);
        */
    }

    public void Attack()
    {
        if(Input.GetKeyDown(shootKey)) 
        {
            //projectile.FireProjectile();
        }
    }

}
