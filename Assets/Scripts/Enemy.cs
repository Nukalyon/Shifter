using Cinemachine;
using System;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable
{
    [SerializeField] private float maxHealth = 10f;
    private float currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        if(currentHealth <= 0)
        {
            CineMachineCameraShake(10.0f, 2.0f);
            Destroy(gameObject);
        }
    }

    private void CineMachineCameraShake(float intensity, float duration)
    {
        //Recherche de la Camera virtuelle de cinemachine
        CinemachineVirtualCamera camera = GameObject.Find("Virtual Camera").GetComponent<CinemachineVirtualCamera>();
        if (camera != null)
        {
            camera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = intensity;
            camera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_FrequencyGain = duration;
        }
    }
}
