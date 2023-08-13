using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunAnimator : MonoBehaviour
{
    Animator gunAnimator;
    void Start()
    {
        gunAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Vertical"))
        {
            gunAnimator.SetTrigger("weapon walk");
        }
        if (Input.GetButtonUp("Vertical"))
        {
            gunAnimator.SetTrigger("weapon idle");
        }
    }
}
