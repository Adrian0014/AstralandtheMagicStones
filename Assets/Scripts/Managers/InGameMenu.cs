using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameMenu : MonoBehaviour
{
    public static bool enPausa = false;
    public GameObject pauseMenu;
    public GameObject selectMenuGame;
    public GameObject interfazInGame;
    public static InGameMenu Instance;

    void Awake() 
    {
        if( Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && Global.PlayerScript == false)
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
        selectMenuGame.SetActive(false);
        interfazInGame.SetActive(true);
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
    public void ReturnLobby()
    {
        Debug.Log("PaCasa");
        Time.timeScale = 1f;
        Global.PlayerScript = false;
        SceneManager.LoadScene(0);
    }

    public void LevelSelect()
    {
        Debug.Log("PaCasa");
        Time.timeScale = 0f;
        Global.PlayerScript = true;
        selectMenuGame.SetActive(true);
        interfazInGame.SetActive(false);
        Cursor.lockState = CursorLockMode.Confined;

    }
    public void GoldenLevel()
    {
        Global.nivel = 5;
        PlayerPrefs.SetInt("LevelMax",Global.nivel);
        SceneManager.LoadScene(Global.nivel);
    }
    
    void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Global.nivel = 6;
            PlayerPrefs.SetInt("LevelMax",Global.nivel);
            SceneManager.LoadScene(Global.nivel);
        }
    }
}
