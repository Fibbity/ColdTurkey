using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGarbageCollector : MonoBehaviour
{

    //---------------------------//
    void OnTriggerEnter2D(Collider2D collider)
    //---------------------------//
    {

        if (collider.tag == "Obstacle" || collider.tag == "Forward Pill")//Make Layers?
            {
                Destroy(collider.gameObject);
            }
        
    }//END OnTriggerEnter2D

}//END OGC
