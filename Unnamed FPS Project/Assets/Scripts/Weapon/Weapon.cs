using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera FPCamera;
    [SerializeField] float range = 200f;
    [SerializeField] int damage = 20;
    [SerializeField] float fireRate = 5f;
    [SerializeField] Ammo ammoSlot;
    [SerializeField] AmmoTypes ammoTypes;
    [SerializeField] TextMeshProUGUI ammoText;

    private float nextTimeToFire = 0;

    AudioSource s;
    [SerializeField] AudioClip gunShot;

    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] GameObject hitEffect;

    void Start()
    {
        s = GetComponent<AudioSource>();
    }
    void Update()
    {   
        DisplayAmmo();
        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
        {   
            nextTimeToFire = Time.time + 1f / fireRate; 
            Shoot();
        }
    }
    void Shoot()
    {   
        if (ammoSlot.AmmoAmount(ammoTypes) > 0)
            {   
                PlayMuzzleFlash();
                s.PlayOneShot(gunShot);
                ProcessRaycast();
                ammoSlot.ReduceCurrentAmmo(ammoTypes);
            }
        else
        {
            return;
        }
    }

    private void PlayMuzzleFlash()
    {
        muzzleFlash.Play();
    }

    void ProcessRaycast()
    {   
        RaycastHit hit;
        if (Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, range))
        {
            CreateHitImpact(hit);
            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
            if (target == null) { return; }
            target.TakeDamage(damage);
        }
        else
        {
            return;
        }             
    }

    void CreateHitImpact(RaycastHit hit)
    {
        GameObject impact = Instantiate(hitEffect, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(impact, 1);
    }

    void DisplayAmmo()
    {
        int currentAmmo = ammoSlot.AmmoAmount(ammoTypes);
        ammoText.text = currentAmmo.ToString();
    }
}
