using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InputController : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] SpriteRenderer sr;
    int speed = 5;


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
        if (rb.velocity.x < 0)
        {
            //sr.flipX = true;
            transform.localScale = new Vector3(1,1,1);
        }
        if (rb.velocity.x > 0)
        {
            //sr.flipX = false;
            transform.localScale = new Vector3(-1, 1, 1);
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

    internal void Jump(int force)
    {
        Debug.Log("Jump !");
        rb.AddForce(new Vector2(0, force));
    }
    /*
    internal void Movement(float v1, float v2)
    {
        Vector3 move = new Vector3(v1 * speed.x, v2 * speed.y, 0);
        move *= Time.deltaTime;
        transform.Translate(move);
    }
    */

    internal void Move(int direction)
    {
        rb.velocity = new Vector2(speed * direction, rb.velocity.y);
    }

    internal void Attack()
    {
        Debug.Log("Piou piou");
    }


}