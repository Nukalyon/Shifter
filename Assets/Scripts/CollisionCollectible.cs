using System.Collections.Generic;
using UnityEngine;

public class CollisionCollectible : MonoBehaviour
{
    [SerializeField] Transform collectible;
    [SerializeField] private UIManager manager;
    GameObject player;

    private void Start()
    {
        player = this.GetComponent<GameObject>();
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
        if(collision.CompareTag("PowerColor"))
        {
            //Ajouter la couleur dans l'inventaire du joueur
            Color color = collision.gameObject.GetComponent<SpriteRenderer>().color;
            Vector2 vect = collision.gameObject.transform.position;
            Item item = new Item(color, vect.x, vect.y);
            manager.AddPower(item);
            collision.gameObject.SetActive(false);
        }
    }
}
