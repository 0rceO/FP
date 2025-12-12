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

    NavMeshAI navMeshAI;
    CapsuleCollider zombieCollider;
    [SerializeField] Animator zombieAnimator;
    // Start is called before the first frame update
    void Start()
    {
        navMeshAI = GetComponent<NavMeshAI>();
        zombieCollider = GetComponent<CapsuleCollider>();
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
            StartCoroutine(OnKilled());
        }
    }

    IEnumerator OnKilled()
    {
        zombieAnimator.SetTrigger("Dead");
        soundManager.playSFX(soundManager.zombieDeath);
        navMeshAI.agent.speed = 0;
        navMeshAI.agent.velocity = Vector3.zero;
        navMeshAI.agent.destination = transform.position;
        zombieCollider.enabled = false;

        yield return new WaitForSeconds(1);

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
