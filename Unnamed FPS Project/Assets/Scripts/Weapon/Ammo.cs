using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{   
    [SerializeField] AmmoSlot[] ammoSlots;

    [System.Serializable]
    private class AmmoSlot
    {
        public int ammoAmount;
        public AmmoTypes ammoTypes;
    }

    public int AmmoAmount(AmmoTypes ammoTypes)
    {   
        return GetAmmoSlot(ammoTypes).ammoAmount;
    } 

    public void ReduceCurrentAmmo(AmmoTypes ammoTypes)
    {
        GetAmmoSlot(ammoTypes).ammoAmount--;
    }

    public void IncreaseCurrentAmmo(AmmoTypes ammoTypes, int ammoAmount)
    {
        GetAmmoSlot(ammoTypes).ammoAmount += ammoAmount;
    }
    
    private AmmoSlot GetAmmoSlot(AmmoTypes ammoTypes)
    {
        foreach(AmmoSlot ammoSlot in ammoSlots)
        {
            if (ammoSlot.ammoTypes ==  ammoTypes)
            {
                return ammoSlot;
            }
        }
        return null;
    }
}
