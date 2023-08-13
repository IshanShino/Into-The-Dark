using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunSprint : MonoBehaviour
{
    Animator gunAnimator;
    void Start()
    {
        gunAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            gunAnimator.SetTrigger("weapon sprint");
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            gunAnimator.SetTrigger("weapon walk");
        }
    }
}
