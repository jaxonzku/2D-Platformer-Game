using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    
    private static SoundManager instance;
    public static SoundManager Instance { get { return instance; } }



    public AudioSource soundEffect;
    public AudioSource soundMusic;   
    public SoundType[] Sounds;
    public bool IsMute = false;
    public float Volume = 1f;


    private void Awake()
    {
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
    public void Mute(bool status)
    {
        IsMute = status;
    }


    public void SteVolume(float volume)
    {
        Volume = volume;
        soundEffect.volume = Volume;
        soundMusic.volume = Volume ;
   
    }
    private void Start()
    {
        PlayMusic(global::Sounds.Music);

    }

    public void PlayMusic(Sounds sound)
    {
        if (IsMute)
            return;
        AudioClip clip = getSoundClip(sound);

        if (clip != null)
        {
            soundMusic.clip = clip;
            soundMusic.Play();
        }
        else
        {
            Debug.LogError("clip not found");

        }

    }
    public void Play(Sounds sound)
    {
        if (IsMute)
            return;
        AudioClip clip = getSoundClip(sound);
        if (clip != null)
        {
            soundEffect.PlayOneShot(clip);

        }
        else{
            Debug.LogError("clip not found");

        }

    }

    private AudioClip getSoundClip(Sounds sound)
    {
        SoundType item= Array.Find(Sounds, clip => clip.soundType == sound);
        if (item != null)
            return item.SoundClip;
        return null;


    }
}


[Serializable]
public class SoundType
{
    public Sounds soundType;
    public AudioClip SoundClip;
}

public enum Sounds
{
    ButtonClick,
    Music,
    PlayerMove,
    PlayerDeath,
    EnemyDeath
}
