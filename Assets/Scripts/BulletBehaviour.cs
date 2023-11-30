using InguzPings;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// REFERENCE
//  https://youtu.be/zYN1LTMdFYg?t=825

public class BulletBehaviour : MonoBehaviour
{
    private Rigidbody2D rb;
    private AudioManager manager;
    [SerializeField] private ParticleSystem particle;

    [Header("General Bullet Stats")]
    [SerializeField] private LayerMask whatDestroyBullet;
    [SerializeField] private float destroyTime = 2;

    [Header("Normal Bullet Stats")]
    [SerializeField] private float normalBulletSpeed = 15f;
    [SerializeField] private float normalBulletDamage = 2f;

    [Header("Physics Bullet Stats")]
    [SerializeField] private float physicsBulletSpeed = 35f;
    [SerializeField] private float physicsBulletGravity = 3f;
    [SerializeField] private float physicsBulletDamage = 2f;

    private float damage;
    //Pooling system
    private Queue<GameObject> queue = null;
    private Coroutine cr;

    public enum BulletType
    {
        Normal,
        Physics
    }
    public BulletType bulletType;

    //Awake then OnEnable then Start

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        manager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
    }

    //Happen everytime !
    private void OnEnable()
    {
        //Change rb stats based on bullet type
        SetRbStats();

        //Set velocity based on bullet type
        InitializeBulletStats();
        //SetDestroyTime();
        //S'il existe deja une corroutine
        if (cr != null)
        {
            StopCoroutine(cr);
        }
        cr = StartCoroutine(ReturnToPoolCoRoutine());
    }

    private void FixedUpdate()
    {
        if (bulletType == BulletType.Physics)
        {
            //Rotate bullet in direction of velocity
            if (rb != null)
            {
                transform.right = rb.velocity;
            }
        }
    }

    private void SetRbStats()
    {
        switch (bulletType)
        {
            case BulletType.Normal:
                rb.gravityScale = 0f;
                break;
            case BulletType.Physics:
                rb.gravityScale = physicsBulletGravity;
                break;
        }
    }

    private void SetDestroyTime()
    {
        //Destroy(gameObject, destroyTime);
        Invoke("ReturnToPool", destroyTime);
    }

    private void InitializeBulletStats()
    {
        switch (bulletType)
        {
            case BulletType.Normal:
                SetStraightVelocity();
                damage = normalBulletDamage;
                break;
            case BulletType.Physics:
                SetPhysicVelocity();
                damage = physicsBulletDamage;
                break;
        }
    }

    private void SetPhysicVelocity()
    {
        rb.velocity = transform.right * physicsBulletSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        bool attackEnemy = false;
        //Bitwise operator
        if ((whatDestroyBullet.value & (1 << collision.gameObject.layer)) > 0)
        {
            if (collision.gameObject.layer == 6)
            {
                Color colEnemy = collision.GetComponent<SpriteRenderer>().color;
                Color ourColor = this.GetComponent<SpriteRenderer>().color;
                Debug.Log(ourColor);
                Debug.Log(colEnemy);
                if (ourColor == colEnemy)
                {
                    attackEnemy = true;
                }
            }
            if(attackEnemy)
            {
                //Damage enemy
                IDamageable damageable = collision.GetComponent<IDamageable>();
                if (damageable != null)
                {
                    //Damage enemy
                    damageable.TakeDamage(damage);
                }
            }
            //Spawn particules
            ParticleSystem particule = Instantiate(particle, transform.position, Quaternion.identity);
            Destroy(particule, 2);
            //Play sound FX
            manager.PlaySong("splash");
            //Screenshake
            //CameraShake.instance.ShakeCamera(2, 10);
            //Destroy bullet without pooling system
            //Destroy(gameObject);

            //With Pooling system
            ReturnToPool();

        }
    }

    private void SetStraightVelocity()
    {
        rb.velocity = transform.right * normalBulletSpeed;
    }

    private void ReturnToPool()
    {
        queue.Enqueue(this.gameObject);
        this.gameObject.SetActive(false);
    }

    public void SetPoolRef(Queue<GameObject> refPool)
    {
        this.queue = refPool;
    }

    //Co-routine
    IEnumerator ReturnToPoolCoRoutine()
    {
        yield return new WaitForSeconds(destroyTime);
        ReturnToPool();
    }
}
