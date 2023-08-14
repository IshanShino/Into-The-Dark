using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimDownSight : MonoBehaviour
{
    Animator gunAnimator;
    [SerializeField] Canvas crosshairCanvas;

    void Start()
    {
        gunAnimator = GetComponent<Animator>();
        crosshairCanvas.enabled = true;
    }
    void Update()
    {
        if(Input.GetMouseButtonDown(1))
        {
            gunAnimator.SetBool("aim", true);
            crosshairCanvas.enabled = false;
        }
        if(Input.GetMouseButtonUp(1))
        {
            gunAnimator.SetBool("aim", false);
            crosshairCanvas.enabled = true;
        }
    }
}
