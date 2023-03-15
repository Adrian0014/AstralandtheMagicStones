using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject menuStart;
    public GameObject playMenu;
    public GameObject profileMenu;
    public GameObject optionsMenu;
    public GameObject creditsMenu;


    public void OpenMainMenu()
    {
        menuStart.SetActive(false);
        playMenu.SetActive(true);
        profileMenu.SetActive(false);
        optionsMenu.SetActive(false);
        creditsMenu.SetActive(false);

    }

    public void OpenPlay()
    {
        menuStart.SetActive(false);
        playMenu.SetActive(false);
        profileMenu.SetActive(true);
        optionsMenu.SetActive(false);
        creditsMenu.SetActive(false);

    }

    public void OpenOptions()
    {
        menuStart.SetActive(false);
        playMenu.SetActive(false);
        profileMenu.SetActive(false);
        optionsMenu.SetActive(true);     
        creditsMenu.SetActive(false);

    }

    public void OpenAudioOptions()
    {
        menuStart.SetActive(false);
        playMenu.SetActive(false);
        optionsMenu.SetActive(false);
        creditsMenu.SetActive(false);

    }

    public void OpenGraphicsOptions()
    {
        menuStart.SetActive(false);
        playMenu.SetActive(false);
        profileMenu.SetActive(false);
        optionsMenu.SetActive(false);
        creditsMenu.SetActive(false);

    }

    public void OpenControlsOptions()
    {
        menuStart.SetActive(false);
        playMenu.SetActive(false);
        profileMenu.SetActive(false);
        optionsMenu.SetActive(false);
        creditsMenu.SetActive(false);

    }

    public void OpenCredits()
    {
        menuStart.SetActive(false);
        playMenu.SetActive(false);
        profileMenu.SetActive(false);
        optionsMenu.SetActive(false);
        creditsMenu.SetActive(true);

    }

    public void OpenExit()
    {
        menuStart.SetActive(false);
        playMenu.SetActive(false);
        profileMenu.SetActive(false);
        optionsMenu.SetActive(false);
        creditsMenu.SetActive(false);

    }

    

    public void LoadScene()
    {
        SceneManager.LoadScene("Tutorial");
    }

    public void ExitGame()
    {
        Application.Quit();
    }


}
