using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cinematic : MonoBehaviour
{
    [SerializeField] private float cinematicTime = 0f;
    [SerializeField] private float cinematicPart;
    void Update()
    {
        cinematicTime += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Escape) && cinematicPart == 1)
        {
            SceneManager.LoadScene(3);
        }

        if (Input.GetKeyDown(KeyCode.Escape) && cinematicPart == 2)
        {
            SceneManager.LoadScene(5);
        }
        /*
        if(cinematicTime > 5f)
        {
            if(cinematicPart == 1)
            {
                SceneManager.LoadScene(3);
            }
            if(cinematicPart == 2)
            {
                Debug.Log("Fianl");
                SceneManager.LoadScene(5);
            }  
        }
        */
        if(cinematicTime > 59f && cinematicPart == 1)
        {
            SceneManager.LoadScene(3);
 
        }
        if(cinematicTime > 17f && cinematicPart == 2)
        {

            SceneManager.LoadScene(5);
        
        }
    }
}