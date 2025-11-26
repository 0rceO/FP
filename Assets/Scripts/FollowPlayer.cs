using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public float speed = 2.0f;
    public Transform player;
    public Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void FollowPlayerpos()
    {
        Vector3 pos = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        rb.MovePosition(pos);
        transform.LookAt(player);
    }
    // Update is called once per frame
    void Update()
    {
        FollowPlayerpos();
    }
}
