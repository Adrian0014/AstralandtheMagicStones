using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{

    public float bulletSpeed;

    private Rigidbody rBody;

    public GameObject particulas;

    public GameObject proyectil;
    

    void Awake()
    {
        rBody = GetComponent<Rigidbody>();
    }

    void Start()
    {
        rBody.AddForce(transform.forward * bulletSpeed);
        
        Destroy(gameObject, 5f);
    }
   
   void OnTriggerEnter(Collider collider)
   {
        if(collider.gameObject.tag == "Antorcha")
       {
            //GameManager.Instance.Activacion(collider.gameObject);
            
            fireImpact();
       }       
       else
       {
            fireImpact();
       }
    }

    void fireImpact()
    {
        Destroy(rBody);
        proyectil.SetActive(false);
        particulas.SetActive(true);
        Destroy(gameObject, 1f);
    }
}
