using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathHandler : MonoBehaviour
{
    [SerializeField] Canvas youDiedCanvas;
    [SerializeField] Canvas crosshairCanvas;
    void Start()
    {
        youDiedCanvas.enabled = false;
    }

    public void HandleDeath()
    {
        youDiedCanvas.enabled = true;
        Time.timeScale = 0;
        AudioListener.volume = 0;
        FindObjectOfType<WeaponSwitch>().enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        crosshairCanvas.enabled = false;      
    }
}
