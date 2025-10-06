using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wepon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject Bullet;
    public int ammoCount = 10;
    public float fireRate;
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && ammoCount != 0)
        {
            Shoot();
            ammoCount -= 1;
            Debug.Log(ammoCount);
        }
        if (Input.GetKeyDown("r"))
        {
            ammoCount = 10;
            Debug.Log("Reload");
        }
    }

    void Shoot(){
        Instantiate(Bullet, firePoint.position, firePoint.rotation);
    }
}
