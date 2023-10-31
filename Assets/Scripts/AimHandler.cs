using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class AimHandler : MonoBehaviour
{
    const float MAX_UP_ANGLE = 90f;
    const float MAX_DOWN_ANGLE = -90f;
    [SerializeField] private GameObject weapon;
    private SpriteRenderer weaponRenderer;
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform bulletSpawnPoint;
    private Transform parent;

    private GameObject bulletInst;

    private Vector2 worldPos;
    private Vector2 direction;
    [SerializeField] private float angle;

    private void Start()
    {
        parent = GetComponent<Transform>();
        weaponRenderer = weapon.GetComponent<SpriteRenderer>();
    }


    // Update is called once per frame
    void Update()
    {
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

        //flip the gun when it reaches a 90� threshold
        angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        Vector3 localScale = weapon.transform.localScale;
        //Vector3 localScale = new Vector3(1f,1f,1f);
        //Switch sur la localScale du jour pour savoir si flip ou pas -> gere l'angle
        switch(parent.transform.localScale.x)
        {
            //Joueur vers la droite
            case 1:
                //RotationPlayerNotFlipped(ref localScale);
                break;
            //Joueur vers la gauche
            case -1:
                //RotationPlayerFlipped(ref localScale);
                break;
            default:
                break;
        }
        weapon.transform.localScale = localScale;
    }

    private void RotationPlayerFlipped(ref Vector3 localScale)
    {
        weaponRenderer.flipX = true;
        weaponRenderer.flipY = true;
        float newX = bulletSpawnPoint.transform.position.x;
        float newY = bulletSpawnPoint.transform.position.y;
        //bulletSpawnPoint.transform.position = new Vector2(-Mathf.Abs(newX), newY);
        if (weapon.transform.localEulerAngles.z > MAX_UP_ANGLE && weapon.transform.localEulerAngles.z < MAX_DOWN_ANGLE)
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
        weaponRenderer.flipX = false;
        weaponRenderer.flipY = false;
        float newX = bulletSpawnPoint.transform.position.x;
        float newY = bulletSpawnPoint.transform.position.y;
        //bulletSpawnPoint.transform.position = new Vector2(Mathf.Abs(newX), newY);
        if (weapon.transform.localEulerAngles.z > MAX_UP_ANGLE && weapon.transform.localEulerAngles.z < MAX_DOWN_ANGLE)
        {
            localScale.y = -Mathf.Abs(localScale.y);
            //bulletSpawnPoint.position = new Vector3(-newX, newY, weapon.transform.position.z);
        }
        else
        {
            localScale.y = Mathf.Abs(localScale.y);
        }
    }

    private void HandleGunShooting()
    {
        if(Mouse.current.leftButton.wasPressedThisFrame)
        {
            //spawn bullet
            bulletInst = Instantiate(bullet, bulletSpawnPoint.position, weapon.transform.rotation);
        }
    }
}
