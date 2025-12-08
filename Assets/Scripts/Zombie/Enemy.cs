using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Animations;
using UnityEngine.UIElements;

public class Enemy : MonoBehaviour
{
    public Rigidbody rb;
    public float health = 50f;
    public int pointsGet;  
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            OnKilled();
        }
    }
    void OnKilled()
    {
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
