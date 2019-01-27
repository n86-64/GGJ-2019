using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

    public static AudioManager instance;
    public AudioSource gameplayMusicSource;

    public AudioClip bGM;

    public AudioClip engineSound;
    public AudioClip fireSound;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    public void PauseBGM()
    {
        gameplayMusicSource.Pause();
    }

    public void UnPauseBGM()
    {
        gameplayMusicSource.UnPause();
    }

    public void PlayBGMTrack()
    {
        gameplayMusicSource.Play();
    }

    public void PlaySFX(AudioSource source,AudioClip sfxToPlay)
    {
        print("This tried to play");
        source.clip = sfxToPlay;
        source.Play();
    }
    public void StopSFX(AudioSource source)
    {
       
        source.Stop();
    }

}
