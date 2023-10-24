using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{

    [Header("KeyCode Parameters")]
    [SerializeField] private KeyCode jumpKey = KeyCode.Space;
    [SerializeField] private KeyCode shootKey = KeyCode.Mouse0;
    [SerializeField] private KeyCode leftKey = KeyCode.Q;
    [SerializeField] private KeyCode rightKey = KeyCode.D;
    [SerializeField] private KeyCode upKey = KeyCode.Z;
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


    // Update is called once per frame
    void Update()
    {
        Jump();
        Movement();
        Attack();
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
