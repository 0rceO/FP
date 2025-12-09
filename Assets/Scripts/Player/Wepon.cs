using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Wepon : MonoBehaviour
{
    SoundManager soundManager;
    public Transform firePoint;
    public int ammoCount = 20;
    public int maxAmmo = 20;
    public float damage = 10f;
    public float range = 100f;
    public float fireRate = 15f;
    public float reloadTime = 2.0f; // seconds to reload

    public Camera fpsCam;
    public ParticleSystem muzzleFlash1;
    [SerializeField] GameObject muzzleFlash2;
    [SerializeField] GameObject impactEffectPrefab;


    private float nextTimeToFire = 0f;
    private bool isReloading = false;
    private float reloadTimer = 0f;

    [SerializeField] GameObject ammoCountText;
    // Start is called before the first frame update
    void Start()
    {
        soundManager = FindObjectOfType<SoundManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isReloading && Input.GetButton("Fire1") && ammoCount > 0 && Time.time >= nextTimeToFire)
        {   
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
            muzzleFlash1.Play();
            // Instantiate(muzzleFlash2, firePoint.position, firePoint.rotation);
            ammoCount -= 1;
        }
        // Start reload when player presses R or when ammo is 0
        if (!isReloading && (Input.GetKeyDown(KeyCode.R) || ammoCount <= 0))
        {
            if (ammoCount < maxAmmo)
                StartCoroutine(Reload());
        }

        // Update UI: show reloading progress or ammo count
        var textComp = ammoCountText.GetComponent<TextMeshProUGUI>();
        if (isReloading)
        {
            textComp.text = "Reloading... " + reloadTimer.ToString("F1") + "s";
        }
        else
        {
            textComp.text = ammoCount + " / " + maxAmmo;
        }
    }

    void Shoot()
    {
        
        soundManager.playSFX(soundManager.shoot);
        RaycastHit hit;
        if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);
            Enemy enemy = hit.transform.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }
            Instantiate(impactEffectPrefab, hit.point, Quaternion.LookRotation(hit.normal));
        }

    }

    System.Collections.IEnumerator Reload()
    {
        isReloading = true;
        reloadTimer = reloadTime;

        soundManager.playSFX(soundManager.reload);

        while (reloadTimer > 0f)
        {
            reloadTimer -= Time.deltaTime;
            yield return null;
        }

        ammoCount = maxAmmo;
        isReloading = false;
    }
    
    
}
