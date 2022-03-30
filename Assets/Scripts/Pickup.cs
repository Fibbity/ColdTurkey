using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    private PlayerMovement playerMovement;//wtf is this for

    //---------------------------//
    void OnTriggerEnter2D(Collider2D collider)
    //---------------------------//
    {
        if (gameObject.tag == "Forward Pill") //Make Tags Layers
        {
            if (collider.tag == "Player")
            {
                playerMovement = collider.GetComponent<PlayerMovement>();
                playerMovement.MovePlayerForward();
                Destroy(gameObject);
            }
        }
    }//END OnTriggerEnter2D

}//END Pickup
