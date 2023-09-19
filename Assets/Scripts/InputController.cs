using System;
using UnityEngine;

public class InputController : MonoBehaviour
{
    Rigidbody2D rb;
    SpriteRenderer sr;
    Vector2 speed = new Vector2(50, 50);


    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("Start");
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        Flip();
    }

    private void FixedUpdate()
    {
        /*
        //GetKeyCode();
        Vector3 move = new Vector3(dirX * speed.x, dirY * speed.y, 0);

        move *= Time.deltaTime;

        rb.transform.Translate(move);
        */
    }

    void Flip()
    {
        if (rb.velocity.x < 0)
        {
            sr.flipX = false;
        }
        if (rb.velocity.x > 0)
        {
            sr.flipX = true;
        }
    }

    private void GetKeyCode()
    {
        foreach (KeyCode vKey in Enum.GetValues(typeof(KeyCode)))
        {
            if (Input.GetKeyDown(vKey))
            {
                Debug.Log("Pressed " + vKey.ToString());
            }
        }
    }

    internal void Jump()
    {
        Debug.Log("Jump !");
    }

    internal void Movement(float v1, float v2)
    {
        Vector3 move = new Vector3(v1 * speed.x, v2 * speed.y, 0);
        move *= Time.deltaTime;
        rb.transform.Translate(move);
    }

    internal void Attack()
    {
        Debug.Log("Piou piou");
    }
}