using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{

    [Header("KeyCode Parameters")]
    [SerializeField] private KeyCode jumpKey = KeyCode.Space;
    [SerializeField] private KeyCode shootKey = KeyCode.Mouse0;
    /*
    [SerializeField] private KeyCode leftKey = KeyCode.Q;
    [SerializeField] private KeyCode rightKey = KeyCode.D;
    [SerializeField] private KeyCode upKey = KeyCode.Z;
    [SerializeField] private KeyCode botKey = KeyCode.S;
    */
    [SerializeField] private string axisX = "player_X";
    [SerializeField] private string axisY = "player_Y";

    [Header("Object References")]
    [SerializeField] private InputController player;
    [SerializeField] private FireingBehaviour projectile;


    // Update is called once per frame
    void Update()
    {
        Jump();
        Movement();
        Attack();
    }

    public void Jump()
    {
        if(Input.GetKeyDown(jumpKey))
        {
            //Jump!
            player.Jump();
        }
    }

    public void Movement()
    {
        float dirX = Input.GetAxisRaw(axisX);
        float dirY = Input.GetAxisRaw(axisY);

        player.Movement(dirX, dirY);
    }

    public void Attack()
    {
        if(Input.GetKeyDown(shootKey)) 
        {
            projectile.FireProjectile();
        }
    }

}
