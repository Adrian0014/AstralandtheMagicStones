using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Antorchas : MonoBehaviour
{

    public GameObject Llamas;
    public GameObject Puerta;
    [SerializeField] private GameObject camaraAntorcha;

    private Rigidbody DoorRigg;



    void Start()
    {
        DoorRigg = Puerta.GetComponent<Rigidbody>();
    }


    void OnTriggerEnter(Collider collider)
   {
        if(collider.gameObject.tag == "Caliente")
       {
            
            Llamas.SetActive(true);
       }

        if(this.gameObject.tag == "Antorcha" && collider.gameObject.tag == "Caliente")
        {
            
            Llamas.SetActive(true);
            //GameManager.Instance.Activacion();
            
            DoorRigg.AddForce(0, 50, 0);
            Puerta.GetComponent<Collider>().enabled = false;
            Destroy(Puerta, 4f);
            Debug.Log("Activa");
            camaraAntorcha.SetActive(true);
            Destroy(camaraAntorcha, 4f);
        }
    }
    

    void Congelacion()
    {



    }
}
