using UnityEngine;

public class FireingBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Transform projectileFirePoint;

    private float angle = 90f;

    public void FireProjectile()
    {
        switch(projectileFirePoint.localScale.x)
        {
            case 1:
                angle = -90f;
                break;
            case -1:
                angle = 90f;
                break;
            default:
                break;
        }
        Instantiate(projectilePrefab, projectileFirePoint.position, Quaternion.Euler(0,0,angle));
    }
}
