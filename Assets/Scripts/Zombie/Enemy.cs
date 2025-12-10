using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Animations;
using UnityEngine.UIElements;

public class Enemy : MonoBehaviour
{
    SoundManager soundManager;
    public Rigidbody rb;
    public float health = 50f;
    public int pointsGet;  
    // Start is called before the first frame update
    void Start()
    {
        soundManager = FindObjectOfType<SoundManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health > 0)
        soundManager.playSFX(soundManager.zombieHurt);
        if (health <= 0)
        {
            OnKilled();
        }
    }
    void OnKilled()
    {
        soundManager.playSFX(soundManager.zombieDeath);
        Destroy(gameObject);
        if (GameObject.FindGameObjectWithTag("WaveSpawner") != null)
        {
            GameObject.FindGameObjectWithTag("WaveSpawner").GetComponent<WaveSpawner>().spawnedzombies.Remove(gameObject);
        }
        
        if (GameObject.FindGameObjectWithTag("Points") != null)
        {
            GameObject.FindGameObjectWithTag("Points").GetComponent<Points>().points += pointsGet;
        }
    }
}
