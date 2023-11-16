using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(LineRenderer))]
public class AimHandler : MonoBehaviour
{
    [SerializeField] private GameObject weapon;
    private SpriteRenderer weaponRenderer;
    private Transform parent;

    private Vector2 worldPos;
    private Vector2 direction;
    [SerializeField] private float angle;

    [Header("Trajectory Elements")]
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform bulletSpawnPoint;
    [SerializeField] private LineRenderer trajectory;

    [SerializeField] private float launchForce = 1f;
    [SerializeField] private float trajectoryTimeStep = 0.05f;
    [SerializeField] private int trajectoryStepCount = 50;

    Vector2 velocity, startMousePos, currentMousePos;



    [Header("Pooling System Elements")]
    //Pooling system
    //Fluidifier l'interface hierarchique
    private GameObject categoryProjectileInHierarchy;
    //Type of bullet
    private Queue<GameObject> pooling = new Queue<GameObject>();
    [SerializeField] private int initialPoolSize = 10;
    [SerializeField] private int batchPoolSize = 5;

    private void Awake()
    {
        categoryProjectileInHierarchy = new GameObject("Projectile's Pool");
        AddProjectileToPool(initialPoolSize);
    }

    private void AddProjectileToPool(int nb)
    {
        //Remplissage de la pool de projectiles
        for (int i = 0; i < nb; i++)
        {
            GameObject proj = Instantiate(bullet);
            //Permet de stocker tout les proj dans un seul tab
            proj.transform.parent = categoryProjectileInHierarchy.transform;
            //Empeche le rendu à l'ui
            proj.SetActive(false);
            //Donne la reference de la pool
            proj.GetComponent<BulletBehaviour>().SetPoolRef(pooling);
            pooling.Enqueue(proj);

        }
    }

    private void Start()
    {
        parent          = GetComponent<Transform>();
        weaponRenderer  = weapon.GetComponent<SpriteRenderer>();
    }


    // Update is called once per frame
    void Update()
    {
        /*
        if(Input.GetMouseButtonDown(0))
        {
            startMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        if(Input.GetMouseButton(0))
        {
            //currentMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            velocity = (startMousePos - (Vector2)weapon.transform.position) * launchForce;
            DrawTrajectory();
        }
        */
        HandleGunRotation();
        HandleGunShooting();
    }

    /*  REFERENCE
     * https://www.youtube.com/watch?v=zYN1LTMdFYg&t=7s&ab_channel=SasquatchBStudios
     */
    private void HandleGunRotation()
    {
        //rotate de gun towards mouse position
        worldPos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        direction = worldPos - (Vector2)weapon.transform.position;
        float dist = direction.magnitude;
        direction = direction.normalized;
        weapon.transform.right = direction;

        //flip the gun when it reaches a 90deg threshold
        angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        Vector3 localScale = weapon.transform.localScale;
        //Vector3 localScale = new Vector3(1f,1f,1f);
        //Switch sur la localScale du jour pour savoir si flip ou pas -> gere l'angle
        switch(parent.transform.localScale.x)
        {
            case 1:
                RotationPlayerNotFlipped(ref localScale);
                break;
            case -1:
                RotationPlayerFlipped(ref localScale);
                break;
            default:
                break;
        }
        weapon.transform.localScale = localScale;
    }

    private void RotationPlayerFlipped(ref Vector3 localScale)
    {
        Debug.Log("Player flipped");
        weaponRenderer.flipX = true;
        weaponRenderer.flipY = true;
        float newX = bulletSpawnPoint.transform.position.x;
        float newY = bulletSpawnPoint.transform.position.y;
        //bulletSpawnPoint.transform.position = new Vector2(-Mathf.Abs(newX), newY);
        if (weapon.transform.localEulerAngles.z > 90 || weapon.transform.localEulerAngles.z < -90)
        {
            localScale.y = -Mathf.Abs(localScale.y);
        }
        else
        {
            localScale.y = Mathf.Abs(localScale.y);
        }
    }

    private void RotationPlayerNotFlipped(ref Vector3 localScale)
    {
        Debug.Log("Player not flipped");
        weaponRenderer.flipX = false;
        weaponRenderer.flipY = false;
        float newX = bulletSpawnPoint.transform.position.x;
        float newY = bulletSpawnPoint.transform.position.y;
        //bulletSpawnPoint.transform.position = new Vector2(Mathf.Abs(newX), newY);
        if (weapon.transform.localEulerAngles.z > 90 || weapon.transform.localEulerAngles.z < -90)
        {
            localScale.y = -Mathf.Abs(localScale.y);
        }
        else
        {
            localScale.y = Mathf.Abs(localScale.y);
        }
    }

    private void HandleGunShooting()
    {
        //trajectory.DrawTrajectory(weapon.transform.position, );
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            //spawn bullet before pooling
            //Instantiate(bullet, bulletSpawnPoint.position, weapon.transform.rotation);

            //Regarde si la liste est vide -> Oui: Creer des instances en plus
            if(pooling.Count== 0)
            {
                AddProjectileToPool(batchPoolSize);
            }

            //With Pooling system
            GameObject newProjectile = pooling.Dequeue();
            //Donne le 2eme paramètre
            newProjectile.transform.position = bulletSpawnPoint.position;
            //Donne le 3eme paramètre
            newProjectile.transform.rotation = weapon.transform.rotation;
            //Rendre visible
            newProjectile.SetActive(true);
        }
    }



    /*  REFERENCE
     * https://www.youtube.com/watch?v=IJLRXbSug38&t=209s&ab_channel=LevelUp
     */
    private void DrawTrajectory()
    {
        Vector3[] positions = new Vector3[trajectoryStepCount];
        for(int i = 0; i < trajectoryStepCount; i++)
        {
            float t = i * trajectoryTimeStep;
            Vector3 pos = (Vector2)bulletSpawnPoint.position + velocity * t + 0.5f * Physics2D.gravity* t * t;
            positions[i] = pos;
        }
        trajectory.positionCount = trajectoryStepCount;
        trajectory.SetPositions(positions);
    }
}
