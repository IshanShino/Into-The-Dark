using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera FPCamera;
    [SerializeField] float range = 200f;
    [SerializeField] int damage = 20;
    [SerializeField] float fireRate = 5f;
    [SerializeField] Ammo ammoSlot;
    [SerializeField] float timeBetweenShots = 1f;

    private float nextTimeToFire = 0;

    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] GameObject hitEffect;
    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
        {   
            nextTimeToFire = Time.time + 1f / fireRate; 
            Shoot();
        }
    }
    void Shoot()
    {   
        if (ammoSlot.AmmoAmount > 0)
            {
                PlayMuzzleFlash();
                ProcessRaycast();
                ammoSlot.ReduceCurrentAmmo();
            }
        else
        {
            return;
        }
    }

    private void PlayMuzzleFlash()
    {
        if (muzzleFlash.isPlaying == false)
        {   
            muzzleFlash.Play();
        }
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
}
