using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Animations;
using UnityEngine.UIElements;

public class Enemy : MonoBehaviour
{
    public Rigidbody rb;
    public int health = 5;    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Bullet")
        {
            health -= 1;
        }
        if (health == 0)
        {
            
            Destroy(gameObject);
        }
    }
}
