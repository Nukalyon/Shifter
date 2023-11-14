using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class TrajectoryLine : MonoBehaviour
{
    [Header("Trajectory Display")]
    private LineRenderer lineRenderer;
    public int lineSegments = 100;
    public float timeOfTheFlight = 5.0f;

    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }
    public void DrawTrajectory(Vector3 origin, Vector3 startVelocity)
    {
        float timeStep = timeOfTheFlight / lineSegments;

        Vector3[] lineRendererPoints = CalculateTrajectoryLine(origin, startVelocity, timeStep);

        lineRenderer.positionCount = lineSegments;
        lineRenderer.SetPositions(lineRendererPoints);

    }

    private Vector3[] CalculateTrajectoryLine(Vector3 origin, Vector3 startVelocity, float timeStep)
    {
        Vector3[] lineRendererPoints = new Vector3[lineSegments];
        lineRendererPoints[0] = origin;

        for (int i = 1; i < lineSegments; i++)
        {
            float timeOffset = timeStep * i;
            Vector3 progressBeforeGravity = startVelocity * timeOffset;
            Vector3 gravityOffset = Vector3.up * -0.5f * Physics.gravity.y * timeOffset * timeOffset;
            Vector3 newPosition = origin + progressBeforeGravity - gravityOffset;
            lineRendererPoints[i] = newPosition;
        }
        return lineRendererPoints;
    }
}
