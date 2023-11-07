using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLerp : MonoBehaviour
{
    private Transform target;
    [SerializeField]private Vector3 offset = new Vector3(0, 2, -10);
    [SerializeField]private float smoothTime = 0.25f;
    private Vector3 currentVelocity;

    private void Awake()
    {
        this.target = GetComponent<Transform>();
    }

    private void LateUpdate()
    {
        transform.position = Vector3.SmoothDamp(
            transform.position,
            target.position + offset,
            ref currentVelocity,
            smoothTime
            );
    }
}
