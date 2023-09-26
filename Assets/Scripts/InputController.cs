using System;
using UnityEngine;

public class InputController : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] SpriteRenderer sr;
    Vector2 speed = new Vector2(50, 50);


    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("Start");
        //rb = GetComponentInChildren<Rigidbody2D>();
        //sr = GetComponentInChildren<SpriteRenderer>();
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
            transform.localScale = new Vector3(-1,1,1);
        }
        if (rb.velocity.x > 0)
        {
            //sr.flipX = false;
            transform.localScale = new Vector3(1, 1, 1);
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
        transform.Translate(move);
    }

    internal void Attack()
    {
        Debug.Log("Piou piou");
    }
}