using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int enemyMaxHP = 100;
    [SerializeField] int enemyCurrentHP = 0;

    protected void Start()
    {   
        enemyCurrentHP = enemyMaxHP;
    }
    
    public void TakeDamage(int damage)
    {
        enemyCurrentHP -= damage;
        if (enemyCurrentHP <= 0)
        {
            Destroy(gameObject);
        }
    }
}
