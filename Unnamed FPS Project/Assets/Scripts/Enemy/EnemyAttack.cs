using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] PlayerHealth target;
    [SerializeField] int enemyDamage = 20;
    void Start()
    {
       target = FindObjectOfType<PlayerHealth>();
    }   
    public void AttackHitEvent()
    {   
        if(target == null) { return; }
        target.DamageTaken(enemyDamage);
        target.GetComponent<DisplayDamage>().ShowDamageImpact();
    }
}
