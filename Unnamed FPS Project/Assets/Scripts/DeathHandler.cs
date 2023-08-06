using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathHandler : MonoBehaviour
{
    [SerializeField] Canvas youDiedCanvas;
    void Start()
    {
        youDiedCanvas.enabled = false;
    }

    public void HandleDeath()
    {
        youDiedCanvas.enabled = true;
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
