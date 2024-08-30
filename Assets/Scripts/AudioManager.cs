using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public static AudioManager instance;

    public AudioSource sfxSource;

    public AudioSource musicSource;

    public AudioClip[] sfxClips;

    private void Awake()
    {
        // Ensure there is only one instance of AudioManager
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

    }

    public void PlaySFX(int sfxIndex)
    {
        if (sfxIndex >= 0 && sfxIndex < sfxClips.Length)
        {
            sfxSource.clip = sfxClips[sfxIndex];
            sfxSource.Play();
        }
        else
        {
            Debug.LogWarning("SFX index out of range");
        }
    }

    public void SFXVolume(float volume)
    {
        sfxSource.volume = volume;
    }
  
    public void MusicVolume(float volume)
    {
        musicSource.volume = volume;
    }

   
}

