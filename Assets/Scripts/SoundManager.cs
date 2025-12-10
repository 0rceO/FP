using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [Header("Audio Source")]
    [SerializeField] AudioSource SfxSource;
    
    [Header("Auido Clip")]
    public AudioClip reload;
    public AudioClip shoot;
    public AudioClip zombieDeath;
    public AudioClip zombieHurt;
    public AudioClip playerHurt;
    public AudioClip doorOpen;
    public AudioClip lockedDoor;

    private void Start()
    {


    }

    public void playSFX(AudioClip clip)
    {
        SfxSource.PlayOneShot(clip);
    }
}
