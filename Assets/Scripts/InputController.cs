using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InputController : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] SpriteRenderer sr;
    [SerializeField] private int maxJump = 2;
    [SerializeField] private float maxSlope = 0.8f;
    private int speed = 5;
    private int nbJump = 0;


    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("Start");
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponentInChildren<SpriteRenderer>();
    }

    private void Update()
    {
        Flip();
    }

    void Flip()
    {
        if (rb.velocity.x > 0)
        {
            //sr.flipX = true;
            transform.localScale = new Vector3(1,1,1);
        }
        if (rb.velocity.x < 0)
        {
            //sr.flipX = false;
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }

    internal void Jump(int force)
    {
        if(nbJump++ < maxJump) 
        {
            rb.AddForce(new Vector2(0, force));
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.contacts[0].normal.y > maxSlope)
        {
            nbJump = 0;
        }
    }

    internal void Move(int direction)
    {
        rb.velocity = new Vector2(speed * direction, rb.velocity.y);
    }
<<<<<<< HEAD
=======

    internal void Attack()
    {
        Debug.Log("Piou piou");
    }


>>>>>>> albert
}