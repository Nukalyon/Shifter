using System.Collections.Generic;
using UnityEngine;

public class CollisionCollectible : MonoBehaviour
{
    [SerializeField] Transform collectible;
    [SerializeField] private UIManager manager;


    private void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Collectible"))
        {
            //Debug.Log("Triggered");
            manager.addCollectible();
            collision.gameObject.SetActive(false);
            //Destroy(collision.gameObject);
        }
    }
}
