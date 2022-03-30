using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGarbageCollector : MonoBehaviour
{

    //---------------------------//
    void OnTriggerEnter2D(Collider2D collider)
    //---------------------------//
    {

        if (collider.gameObject.layer == LayerMask.NameToLayer("Platform") || 
            collider.gameObject.layer == LayerMask.NameToLayer("Obstacle") || 
            collider.gameObject.layer == LayerMask.NameToLayer("Pickup"))
        {
            Destroy(collider.gameObject);
        }

    }//END OnTriggerEnter2D

}//END OGC
