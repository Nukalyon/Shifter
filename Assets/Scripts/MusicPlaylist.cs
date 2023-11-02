using UnityEngine;

[RequireComponent(typeof(UnityEngine.AudioSource))]
public class Playlist : MonoBehaviour
{
    [SerializeField] private AudioClip[] playlist;
    private UnityEngine.AudioSource audioSource;
    private int musicIndex = 0;

    private void Awake()
    {
        audioSource = GetComponent<UnityEngine.AudioSource>();
        PlayNextMusic();
    }


    private void Update()
    {
        if(!audioSource.isPlaying)
        {
            PlayNextMusic();
        }
    }

    private void PlayNextMusic()
    {
        audioSource.clip= playlist[musicIndex++];
        audioSource.Play();

        musicIndex %= playlist.Length;
    }
}
