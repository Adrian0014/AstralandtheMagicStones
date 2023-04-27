using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    [SerializeField] private LayerMask gorundLayer;

    void Update()
    {
        transform.position += transform.forward * 20 * Time.deltaTime;
    }

        
    void OnTriggerEnter(Collider collider)
    {
        if (gorundLayer == (gorundLayer | (1 << collider.gameObject.layer)))
        {
        // El objeto colisionado está en una de las capas especificadas en targetLayers
        // Aquí pones el código que quieras que se ejecute al detectar una de las capas específicas
        Debug.Log("La bala ha chocado con una de las capas especificadas en targetLayers");
        this.gameObject.SetActive(false);

        }

        

    }
}
