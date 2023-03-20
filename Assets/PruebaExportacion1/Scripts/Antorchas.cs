using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Antorchas : MonoBehaviour
{

    public GameObject Llamas;


    void OnTriggerEnter(Collider collider)
   {
        if(collider.gameObject.tag == "Caliente")
       {
            
            Llamas.SetActive(true);
       }

        if(this.gameObject.tag == "Antorcha" && collider.gameObject.tag == "Caliente")
        {
            
            Llamas.SetActive(true);
            GameManager.Instance.Activacion();
        }
    }
    
}
