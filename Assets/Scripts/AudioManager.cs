using System;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioClip[] soundEffects;
    [SerializeField] Sons[] sons;
    private List<AudioSource> audioSources = new List<AudioSource>();

    #region Singleton
    private static AudioManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            //Persistance du GameMode
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    #endregion

    public void PlaySong(string nom)
    {
        switch(nom)
        {
            case "fireball":
                PlaySongs(0);
                break;
            case "iceball":
                PlaySongs(1);
                break;
        }
    }

    public void PlaySongs(int index)
    {
        foreach(UnityEngine.AudioSource source in audioSources)
        {
            if(!source.isPlaying)
            {
                source.clip = soundEffects[index];
                source.Play();
                return;
            }
        }

        //Create AudioSource
        UnityEngine.AudioSource sr = CreateAudioSource();
        sr.clip = soundEffects[index];
        sr.Play();
    }

    private UnityEngine.AudioSource CreateAudioSource()
    {
        //Creer un nouveau objet
        GameObject go = new GameObject();
        go.name = "AudioSource";
        go.transform.parent = this.transform;

        //AJoute l'audiosource
        UnityEngine.AudioSource ausr =  go.AddComponent<UnityEngine.AudioSource>();
        audioSources.Add(ausr);
        return ausr;
    }
}

[Serializable]
public struct Sons
{
    public string nameCLip;
    public AudioClip son;
}