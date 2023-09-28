using UnityEngine;

public class FireingBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Transform projectileFirePoint;

    public void FireProjectile()
    {
        Debug.Log("Piou piou !" + gameObject.name);
        Instantiate(projectilePrefab, projectileFirePoint.position, Quaternion.identity);
    }
}
