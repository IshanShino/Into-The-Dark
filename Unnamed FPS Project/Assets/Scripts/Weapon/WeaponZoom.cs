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
    void OnDisable()
    {
        ZoomOut();
    }
    void Start()
    {   
        FPCamera = FindObjectOfType<CinemachineVirtualCamera>();
    }

    void Update()
    {   
        if (Input.GetMouseButtonDown(1))
        {   
            if (zoomedIn == false)
            {
                ZoomIn();
            }
            else
            {   
                ZoomOut();
            }
        }      
    }

    public void ZoomIn()
    {   
        zoomedIn = true;
        FPCamera.m_Lens.FieldOfView = zoomedInFOV;
    }

    public void ZoomOut()
    {   
        zoomedIn = false;
        FPCamera.m_Lens.FieldOfView = defaultFOV;
    }        
}
