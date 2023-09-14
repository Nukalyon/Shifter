using System;
using UnityEngine;

public class InputController : MonoBehaviour
{
    Rigidbody2D rb;
    SpriteRenderer sr;
    Vector2 speed = new Vector2(50, 50);
    public string axisX;
    public string axisY;
    bool facingRight = false;


    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("Start");
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        float dirX = Input.GetAxisRaw(axisX);
        float dirY = Input.GetAxisRaw(axisY);
        GetKeyCode();
        Vector3 move = new Vector3(dirX * speed.x, dirY * speed.y, 0);

        move *= Time.deltaTime;

        transform.Translate(move);

        if(dirX < 0)
        {
            Flip(false);
        }
        if(dirX > 0)
        {
            Flip(true);
        }
    }

    void Flip(bool val)
    {
        sr.flipX = val;

        facingRight = !facingRight;
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
}