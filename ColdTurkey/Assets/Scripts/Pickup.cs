using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    private PlayerMovement playerMovement;

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (gameObject.tag == "Forward Pill")
        {
            if (collider.tag == "Player")
            {
                playerMovement = collider.GetComponent<PlayerMovement>();
                playerMovement.MovePlayerForward();
                Destroy(gameObject);
            }
        }
    }
}
