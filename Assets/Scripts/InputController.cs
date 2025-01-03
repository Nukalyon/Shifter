using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InputController : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] SpriteRenderer sr;
    private Vector3 initialPosition;

    [SerializeField] private int maxJump = 2;
    [SerializeField] private float maxSlope = 0.8f;
    private int speed = 10;
    private int nbJump = 0;


    // Start is called before the first frame update
    void Awake()
    {
        //DontDestroyOnLoad(this.gameObject);

        rb = GetComponent<Rigidbody2D>();
        sr = GetComponentInChildren<SpriteRenderer>();
        initialPosition = transform.position;

        //if (rb == null || sr == null)
        //{
        //    Debug.Log("Rigbody components have been destroyed...");
        //}
        //else
        //{
        //    rb = GetComponent<Rigidbody2D>();
        //    sr = GetComponentInChildren<SpriteRenderer>();
        //}
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
    public void ResetPosition()
    {
        transform.position = initialPosition;
    }
}