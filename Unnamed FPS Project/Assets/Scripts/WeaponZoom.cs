using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class WeaponZoom : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera FPCamera;
    [SerializeField] float defaultFOV = 40f;
    [SerializeField] float zoomedInFOV = 25f;

    bool zoomedIn = false;
    void Start()
    {   
        FPCamera = FindObjectOfType<CinemachineVirtualCamera>();
    }

    void Update()
    {   
        if (Input.GetMouseButtonDown(1))
        {   
            ZoomView();
        }
    }

    public void ZoomView()
    {
        if (zoomedIn == false)
            {  
                zoomedIn = true;
                FPCamera.m_Lens.FieldOfView = zoomedInFOV;
            }
            else
            {   
                zoomedIn = false;
                FPCamera.m_Lens.FieldOfView = defaultFOV;
            }     
    }
}
