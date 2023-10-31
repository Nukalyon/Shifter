using UnityEngine;

public class Projectile : MonoBehaviour
{
<<<<<<< HEAD
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
=======
    [SerializeField] private float vitesse = 10;

    [SerializeField] private float lifetime = 5;

    [SerializeField] private int degats = 5;

    Rigidbody2D rb = new Rigidbody2D();

    // Update is called once per frame
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * vitesse;

        Destroy(this.gameObject, lifetime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //1. Tag

        //if (collision.CompareTag("Enemy"))
        //{
        //    Debug.Log("Triggered");
        //    GetComponent<Health>().TakeDamage(degats);
        //}

        Health health = collision.GetComponent<Health>();

        if (health)
        {
            health.TakeDamage(degats);
            Destroy(this.gameObject);
        }

        //2. Name
        //3. Layer
        //4. Component
        //5. Interface
>>>>>>> albert
    }
}
