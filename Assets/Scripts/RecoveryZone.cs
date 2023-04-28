using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecoveryZone : MonoBehaviour
{
    
    void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.CompareTag("Player"))
        {
            Debug.Log("Curateputa");
            Global.vidas = 3;
            GameManager.Instance.Recuperacion();
        }
    }
}
