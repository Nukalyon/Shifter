using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class AimHandler : MonoBehaviour
{
    [SerializeField] private GameObject weapon;
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform bulletSpawnPoint;

    private GameObject bulletInst;

    private Vector2 worldPos;
    private Vector2 direction;
    private float angle;

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
        direction = (worldPos - (Vector2)weapon.transform.position).normalized;
        weapon.transform.right = direction;

        //flip the gun when it reaches a 90° threshold
        angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        Vector3 localScale = Vector3.one;
        //Vector3 localScale = new Vector3(1f,1f,1f);
        if (angle > 90 || angle < -90)
        {
            localScale.y = -1f;
        }
        else
        {
            localScale.y = 1f;
        }
        weapon.transform.localScale = localScale;
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
