using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float vitesse = 10f;
    [SerializeField] private float lifetime = 2f;
    [SerializeField] private int damage = 5;
    private Rigidbody2D rb;
    
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.up * vitesse;

        Destroy(this.gameObject, lifetime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        /* 1. Tags
        if(collision.CompareTag("Enemy"))
        {
            Debug.Log("Triggered");
            collision.GetComponent<Health>().TakeDamage(damage);
        }
        */
        Health health = collision.GetComponent<Health>();
        if(health != null ) 
        {
            health.TakeDamage(damage);
            Destroy(this.gameObject);
        }

        // 2. Name
        // 3. Layer
        // 4. Component


        // 5. Interface
    }
}
