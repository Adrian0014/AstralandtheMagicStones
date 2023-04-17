using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameMenu : MonoBehaviour
{
    public static bool enPausa = false;
    public GameObject pauseMenu;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(enPausa)
            {
                ContinuePlay();
            }
            else
            {
                Pause();
            }
        }
    }

    public void ContinuePlay()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        enPausa = false;
        Global.PlayerScript = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        enPausa = true;
        Global.PlayerScript = true;
        Cursor.lockState = CursorLockMode.Confined;

    }
}