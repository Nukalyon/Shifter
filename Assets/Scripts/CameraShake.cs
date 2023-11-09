using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{

    public static CameraShake instance;
    private float duration, intensity;
    private float timer = 0;
    private bool isShaking = false;
    private Vector3 initialPos;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this);
        }
    }

    private void Update()
    {
        if (!isShaking) return;

        timer += Time.deltaTime;
        if(timer > duration)
        {
            isShaking = false;
            timer = 0;
        }
        this.transform.position = initialPos + (Random.insideUnitSphere * this.intensity);
    }

    public void ShakeCamera (float duration, float intensity)
    {
        this.duration = duration;
        this.intensity= intensity;

        initialPos = this.transform.position;
        isShaking= true;
    }
}
