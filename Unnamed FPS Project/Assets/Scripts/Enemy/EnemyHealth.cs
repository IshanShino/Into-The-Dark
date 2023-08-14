using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int enemyMaxHP = 200;
    [SerializeField] int enemyCurrentHP = 0;
    [SerializeField] AudioClip deathSFX;

    bool isDead = false;

    AudioSource s;

    public bool IsDead()
    {
        return isDead; 
    }
    void Start()
    {   
        enemyCurrentHP = enemyMaxHP;
        s = GetComponent<AudioSource>();
    }
    
    public void TakeDamage(int damage)
    {   
        BroadcastMessage("OnDamageTaken");
        enemyCurrentHP -= damage;
        if (enemyCurrentHP <= 0)
        {
            Die();
        }
    }
    
    void Die() 
    {   
        if (isDead) return;
        isDead = true;
        s.PlayOneShot(deathSFX);
        GetComponent<Animator>().SetTrigger("die");
        
    }
}
