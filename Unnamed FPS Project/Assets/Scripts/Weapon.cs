using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera FPCamera;
    [SerializeField] float range = 200f;
    [SerializeField] int M16Damage = 20;
    [SerializeField] ParticleSystem M16MuzzleFlash;
    [SerializeField] GameObject hitEffect;
    protected void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }
    void Shoot()
    {   
        PlayMuzzleFlash();
        ProcessRaycast();
    }

    private void PlayMuzzleFlash()
    {
        if (M16MuzzleFlash.isPlaying == false)
        {   
            M16MuzzleFlash.Play();
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
            target.TakeDamage(M16Damage);
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
