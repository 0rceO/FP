using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float speed = 20f;

    public Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = transform.forward * speed;
    }

    void OnCollisionEnter (Collision collision)
    {
        if (collision.collider.tag == "Wall" || collision.collider.tag == "Target"|| collision.collider.tag == "Ground")
        {
            Destroy(gameObject);
            Debug.Log("Destroy");
        }
    }
}
