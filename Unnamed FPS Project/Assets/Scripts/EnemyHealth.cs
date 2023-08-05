using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int enemyMaxHP = 200;
    [SerializeField] int enemyCurrentHP = 0;

    void Start()
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
