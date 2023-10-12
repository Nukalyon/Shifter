using UnityEngine;

public class FireingBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Transform projectileFirePoint;
    [SerializeField] private float launchSpeed = 10f;

    private float angle = 90f;

    [Header("Trajectory Display")]
    public LineRenderer lineRenderer;
    public int linePoints = 100;
    public float timeBetweenPoints = 0.01f;

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

    void DrawTrajectory()
    {
        Vector3 origin = projectileFirePoint.position;
        Vector3 startVelocity = launchSpeed * projectileFirePoint.up;
        lineRenderer.positionCount = linePoints;
        float time = 0;
        for(int i = 0; i < linePoints; i++) 
        {
            // s = u * t  * (1/2)*g*t*t
            float x = (startVelocity.x * time) * (Physics2D.gravity.x / 2 * time * time);
            float y = (startVelocity.y * time) * (Physics2D.gravity.y / 2 * time * time);
            Vector3 point = new Vector3(x, y, 0);
            lineRenderer.SetPosition(i, origin + point);
            time += timeBetweenPoints;
        }
    }
}
