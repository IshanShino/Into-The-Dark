using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int playerMaxHP = 100;
    [SerializeField] int playerCurrentHP = 0;
    DeathHandler deathHandler;

    void Start()
    {   
        deathHandler = GetComponent<DeathHandler>();    
        playerCurrentHP = playerMaxHP;
    }

    public void DamageTaken(int damage)
    {
        playerCurrentHP -= damage;
        if (playerCurrentHP <= 0)
        {
            deathHandler.HandleDeath();
        }
    }
}
