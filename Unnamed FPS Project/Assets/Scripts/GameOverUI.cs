using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{   
    [SerializeField] Canvas crosshairCanvas;
    public void ReplayGame()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
        AudioListener.volume = 1;
        crosshairCanvas.enabled = true;
    }                                                                           
    public void QuitApplication()
    {
        Debug.Log("QWUITTT");
    }
}
                                                            