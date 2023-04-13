using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerInteract : MonoBehaviour
{
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

                if(collider.gameObject.CompareTag("Casa1"))
                {
                    Debug.Log("Entrar a casa1");
                    npcInteractable.EntrarCasa1();
                }
                    if(collider.gameObject.CompareTag("PuertaFinal"))
                {
                    Debug.Log("Fianl");
                    SceneManager.LoadScene(4);
                }
            }
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
    /*public NPCCasa GetInteractableObject()
    {
        float interactRange = 2f;
        Collider[] colliderArray = Physics.OverlapSphere (transform.position, interactRange);
        foreach (Collider collider in colliderArray)
        {
            
            if(collider.TryGetComponent(out NPCCasa npcCasa) && collider.gameObject.CompareTag("Casa1"))
            {
                return npcCasa;
            }
    

        }
        return null;
        
    }*/
    
}
