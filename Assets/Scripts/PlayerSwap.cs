using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerSwap : MonoBehaviour
{
    Rigidbody2D pl1;
    public Rigidbody2D pl2;
    // Start is called before the first frame update
    void Start()
    {
        pl1 = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.X))
        {
            Vector2 temp = pl1.position;
            pl1.position = pl2.position;
            pl2.position = temp;
        }
    }
}
