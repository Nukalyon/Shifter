using UnityEngine;

public class CollisionCollectible : MonoBehaviour
{
    [SerializeField] Transform collectible;
    [SerializeField] private UIManager manager;

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Collectible"))
        {
            //Debug.Log("Triggered");
            manager.addCollectible();
            Destroy(collision.gameObject);
        }
    }
}
