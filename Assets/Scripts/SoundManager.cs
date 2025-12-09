using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [Header("Audio Source")]
    [SerializeField] AudioSource sfxSource;
    
    [Header("Auido Clip")]
    public AudioClip reload;
    public AudioClip shoot;

    private void Start()
    {


    }

    public void playSFX(AudioClip clip)
    {
        sfxSource.PlayOneShot(clip);
    }
}
