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


        this.gameObject.SetActive(false);
        /*
        if (Physics.collider()
            this.gameObject.SetActive(false);



        if (collision.gameObject.layer == "theobjectToIgnore")
        {
            Physics.IgnoreCollision(theobjectToIgnore.collider, collider);
        }

        if (Physics.Raycast(groundSensor.position, Vector3.down, sensorRadius, gorundLayer))
        */
    }
}
