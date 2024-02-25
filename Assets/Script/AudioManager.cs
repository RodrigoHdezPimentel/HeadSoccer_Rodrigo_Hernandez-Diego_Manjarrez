using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public AudioSource audioSource;
    public AudioSource audioSourceBackground;

    private void Awake()
    {
       if(instance == null)
        {
            instance = this;
        }
    }
    public void PlayLoopingAudio()
    {
        //Musica
        if (audioSourceBackground != null)
        {
            audioSourceBackground.loop = true;
            audioSourceBackground.Play();
        }
    }
    public void PlayAudio()
    {
        //Sonido gol
        audioSource.Play();
    }
}
