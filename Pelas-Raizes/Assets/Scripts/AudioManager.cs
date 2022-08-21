using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static float volume;
    public static AudioManager instance;

    void Awake()
    {
        if (instance ==null)
        {
            instance = this;
            volume = 1;
        }
        else
        {
            return;
        }

        DontDestroyOnLoad(gameObject);
    }

    public void Play(AudioClip clip, float volume = 1.0f, float pitch = 1.0f)
    {
        foreach(AudioSource source in GetComponentsInChildren<AudioSource>())
        {
            if(source.isPlaying == false)
            {
                source.clip = clip;
                source.volume = volume * AudioManager.volume;
                source.pitch = pitch;
                source.Play();
                break;
            }
        }
    }

    public void Play(AudioClip[] clips, float volume = 1.0f, float pitch = 1.0f)
    {
        foreach(AudioSource source in GetComponentsInChildren<AudioSource>())
        {
            if(source.isPlaying == false)
            {
                source.clip = clips[Random.Range(0, clips.Length)];
                source.volume = volume * AudioManager.volume;
                source.pitch = pitch;
                source.Play();
                break;
            }
        }
    }

    public void Playback(AudioClip clip)
    {
        AudioSource[] sources = GetComponentsInChildren<AudioSource>();
        if(sources[0].clip != clip)
        {
            sources[0].clip = clip;
            sources[0].Play();
        } 
    }

    public void UpdateVolume()
    {
        AudioSource[] sources = GetComponentsInChildren<AudioSource>();
        sources[0].volume = AudioManager.volume;
    }
}
