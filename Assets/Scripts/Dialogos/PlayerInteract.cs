using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField] private GameObject intercativeObject;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            float interactRange = 2f;
            Collider[] colliderArray = Physics.OverlapSphere (transform.position, interactRange);
            foreach (Collider collider in colliderArray)
            {
                if(collider.TryGetComponent(out NPCInteractable npcInteractable) && collider.gameObject.CompareTag("NPC"))
                {
                    npcInteractable.Interact();
                }

                if(collider.gameObject.CompareTag("Casa"))
                {
                    //npcInteractable.EntrarCasa();
                    Debug.Log("Entrar a casa");
                }
                    if(collider.gameObject.CompareTag("PuertaFinal"))
                {
                    Debug.Log("Fianl");
                    SceneManager.LoadScene(3);
                    Global.nivel = 3;
                    PlayerPrefs.SetInt("LevelMax",Global.nivel);
                }
            }
        }
        
        if (GetInteractableObject() != null)
        {
            Show();
        }
        else
        {
            Hide();
        }

    }

    public NPCInteractable GetInteractableObject()
    {
        float interactRange = 2f;
        Collider[] colliderArray = Physics.OverlapSphere (transform.position, interactRange);
        foreach (Collider collider in colliderArray)
        {
            if(collider.TryGetComponent(out NPCInteractable npcInteractable) && collider.gameObject.CompareTag("NPC"))
            {
                return npcInteractable;
            }
            
        }
        return null;
        
    }
    private void Show()
    {
        intercativeObject.SetActive(true);
    }

    private void Hide()
    {
        intercativeObject.SetActive(false);
    }





}
