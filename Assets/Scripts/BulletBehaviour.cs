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

    [Header("General Bullet Stats")]
    [SerializeField] private LayerMask whatDestroyBullet;
    [SerializeField] private float destroyTime = 2;

    [Header("Normal Bullet Stats")]
    [SerializeField] private float normalBulletSpeed = 15f;
    [SerializeField] private float normalBulletDamage = 2f;

    [Header("Physics Bullet Stats")]
    [SerializeField] private float physicsBulletSpeed = 17.5f;
    [SerializeField] private float physicsBulletGravity = 3f;
    [SerializeField] private float physicsBulletDamage = 2f;

    private float damage;
    public enum BulletType
    {
        Normal,
        Physics
    }
    public BulletType bulletType;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        manager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        SetDestroyTime();

        //Change rb stats based on bullet type
        SetRbStats();

        //Set velocity based on bullet type
        InitializeBulletStats();
    }

    private void FixedUpdate()
    {
        if(bulletType == BulletType.Physics)
        {
            //Rotate bullet in direction of velocity
            if(rb != null)
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
        Destroy(gameObject, destroyTime);
    }

    private void InitializeBulletStats()
    {
        switch(bulletType)
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
        //Bitwise operator
        if((whatDestroyBullet.value & (1 << collision.gameObject.layer)) > 0)
        {
            //Spawn particules
            //Play sound FX
            manager.PlaySong("splash"); 
            //Screenshake
            //Damage enemy
            IDamageable damageable = collision.GetComponent<IDamageable>();
            if(damageable != null)
            {
                //Damage enemy
                damageable.TakeDamage(damage);
            }
            //Destroy bullet
            Destroy(gameObject);
        }
    }

    private void SetStraightVelocity()
    {
        rb.velocity = transform.right * normalBulletSpeed;
    }
}
