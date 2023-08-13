using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimDownSight : MonoBehaviour
{
    Animator gunAnimator;

    void Start()
    {
        gunAnimator = GetComponent<Animator>();
    }
    void Update()
    {
        if(Input.GetMouseButtonDown(1))
        {
            gunAnimator.SetBool("aim", true);
        }
        if(Input.GetMouseButtonUp(1))
        {
            gunAnimator.SetBool("aim", false);
        }
    }
}
