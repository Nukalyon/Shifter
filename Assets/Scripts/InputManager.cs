using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [Header("KeyCode Parameters")]
    [SerializeField] private KeyCode jumpKey = KeyCode.Space;
    [SerializeField] private KeyCode shootKey = KeyCode.Mouse0;
    [SerializeField] private KeyCode leftKey = KeyCode.A;
    [SerializeField] private KeyCode rightKey = KeyCode.D;
    [SerializeField] private int jumpForce = 5;
    /*
    [SerializeField] private KeyCode botKey = KeyCode.S; 
    [SerializeField] private string axisX = "player_X";
    [SerializeField] private string axisY = "player_Y";
    */
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
<<<<<<< Updated upstream



        if(Input.GetKeyDown(jumpKey) || Input.GetKeyDown(upKey))
=======
        if(Input.GetKeyDown(jumpKey))
>>>>>>> Stashed changes
        {
            //Jump!
            player.Jump(jumpForce);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.contacts[0].normal.y > 0.7f)
        {
            nombreSautsActuel = 0;
        }
    }

    public void Movement()
    {
        if(Input.GetKeyDown(rightKey))
        {
            player.Move(1);
        }
        else if (Input.GetKeyDown(leftKey))
        {
            player.Move(-1);
        }
        /*
        else
        {
            player.Move(0);
        }
        */
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
            projectile.FireProjectile();
        }
    }

}
