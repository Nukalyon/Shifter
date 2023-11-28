using Cinemachine;
using System.Collections;
using System.Threading;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable
{
    [SerializeField] private float maxHealth = 10f;
    private float currentHealth;
    Coroutine cr = null;



    private void Start()
    {
        currentHealth = maxHealth;
    }


    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        if(currentHealth <= 0)
        {
            if(cr == null)
            {
                cr = StartCoroutine(_ProcessShake());
            }
            Destroy(gameObject);
        }
    }
    private IEnumerator _ProcessShake(float shakeIntensity = 2.0f, float shakeTiming = 2.0f)
    {
        //Noise(1, shakeIntensity);
        CineMachineCameraShake(1, shakeIntensity);
        yield return new WaitForSeconds(shakeTiming);
        CineMachineCameraShake(0, 0);
    }

    private void CineMachineCameraShake(float intensity, float frequency)
    {
        //Recherche de la Camera virtuelle de cinemachine
        CinemachineVirtualCamera camera = GameObject.Find("Virtual Camera").GetComponent<CinemachineVirtualCamera>();
        //Debug.Log("Camera trouvee ? " + camera != null);
        if (camera != null)
        {
            camera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = intensity;
            camera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_FrequencyGain = frequency;

        }
    }
}
