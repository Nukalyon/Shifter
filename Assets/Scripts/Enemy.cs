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
            CineMachineCameraShake(2.0f, 1.0f);
            Destroy(gameObject);
        }
    }
    private IEnumerator _ProcessShake(float shakeIntensity = 2.0f, float shakeTiming = 2.0f)
    {
        Noise(1, shakeIntensity);
        yield return new WaitForSeconds(shakeTiming);
        Noise(0, 0);
    }

    public void Noise(float amplitudeGain, float frequencyGain)
    {
        /*
        cmFreeCam.topRig.Noise.m_AmplitudeGain = amplitudeGain;
        cmFreeCam.middleRig.Noise.m_AmplitudeGain = amplitudeGain;
        cmFreeCam.bottomRig.Noise.m_AmplitudeGain = amplitudeGain;

        cmFreeCam.topRig.Noise.m_FrequencyGain = frequencyGain;
        cmFreeCam.middleRig.Noise.m_FrequencyGain = frequencyGain;
        cmFreeCam.bottomRig.Noise.m_FrequencyGain = frequencyGain;
        */
    }

    private void CineMachineCameraShake(float intensity, float duration)
    {
        //Recherche de la Camera virtuelle de cinemachine
        CinemachineVirtualCamera camera = GameObject.Find("Virtual Camera").GetComponent<CinemachineVirtualCamera>();
        //Debug.Log("Camera trouvee ? " + camera != null);
        if (camera != null)
        {
            camera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = intensity;
            camera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_FrequencyGain = duration;

        }
    }
}
