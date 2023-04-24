using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Antorchas : MonoBehaviour
{

    public GameObject Llamas;
    public GameObject Puerta;
    public  bool activado = false;
    [SerializeField] private GameObject camaraAntorcha;

    private Rigidbody DoorRigg;
    public Animator anim;

    void Start()
    {
        DoorRigg = Puerta.GetComponent<Rigidbody>();
        anim = Puerta.GetComponentInChildren<Animator>();
    }


    void OnTriggerEnter(Collider collider)
   {        
    
        if(collider.gameObject.tag == "Caliente" && activado == false && Global.bigTorch == 2)
        {
            Global.bigTorch++;
            activado = true;
            Llamas.SetActive(true);
            Debug.Log("LUIIIIIIIIS");
            
            camaraAntorcha.SetActive(true);
            anim.SetBool("Desbloqueado", true);
            Destroy(camaraAntorcha, 4f);
            Destroy(Puerta, 4f);

        }
        if(collider.gameObject.tag == "Caliente" && activado == false)
        {
            activado = true;
            Llamas.SetActive(true);
            Debug.Log("carmen");
            Global.bigTorch++;
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
}
