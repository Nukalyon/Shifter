using System;
using UnityEngine;

public class InputController : MonoBehaviour
{
    Vector2 speed = new Vector2(50, 50);
    public string axisX;
    public string axisY;


    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("Start");
    }

    // Update is called once per frame
    void Update()
    {
        float dirX = Input.GetAxisRaw(axisX);
        float dirY = Input.GetAxisRaw(axisY);
        GetKeyCode();

        Vector3 move = new Vector3(dirX * speed.x, dirY * speed.y, 0);

        move *= Time.deltaTime;

        transform.Translate(move);
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