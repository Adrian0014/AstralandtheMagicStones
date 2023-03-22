using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public GameObject[] puntosVidas;

    public static GameManager Instance;

    public GameObject CorrientesAgua;

    public GameObject Puerta;

    private Rigidbody DoorRigg;

    public GameObject puntoApuntando;    


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

    void Start()
    {
        DoorRigg = Puerta.GetComponent<Rigidbody>();
    }

    void Update() 
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {

            CorrientesAgua.GetComponent<Collider>().enabled = false;
        }


        if(Input.GetKeyDown(KeyCode.Alpha4))
        {

            CorrientesAgua.GetComponent<Collider>().enabled = true;
        }
                
        if(Input.GetButton("Fire2"))
        {
            puntoApuntando.SetActive(true);
        }
        else
        {
            puntoApuntando.SetActive(false);
        }      
    }
    
    public void Impacto()
    {
        Global.vidas--;

        if(Global.vidas == 0)
        {
            puntosVidas[0].SetActive(false);
        }


        if(Global.vidas == 1)
        {
            puntosVidas[1].SetActive(false);

        }

        if(Global.vidas == 2)
        {
            puntosVidas[2].SetActive(false);

        }

        if (Global.vidas == 3)
        {
            puntosVidas[3].SetActive(false);

        }

        if (Global.vidas == 4)
        {
            puntosVidas[4].SetActive(false);

        }
    }
}
