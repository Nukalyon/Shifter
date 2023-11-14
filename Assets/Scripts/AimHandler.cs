using System;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(LineRenderer))]
public class AimHandler : MonoBehaviour
{
    [SerializeField] private GameObject weapon;
    private SpriteRenderer weaponRenderer;
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform bulletSpawnPoint;
    private Transform parent;

    private GameObject bulletInst;
    private Vector2 worldPos;
    private Vector2 direction;
    [SerializeField] private float angle;

    [Header("Trajectory Elements")]
    [SerializeField] private LineRenderer trajectory;


    private void Start()
    {
        parent          = GetComponent<Transform>();
        weaponRenderer  = weapon.GetComponent<SpriteRenderer>();
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
            //spawn bullet
            bulletInst = Instantiate(bullet, bulletSpawnPoint.position, weapon.transform.rotation);
        }
    }
}
