using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Obstacle : MonoBehaviour
{
    private PlayerMovement player { get; set; }

    //---------------------------//
    void OnTriggerEnter2D(Collider2D collider)
    //---------------------------//
    {
        if (collider.tag == "Player")
        {
            if (!player.isInvincible)
            {
                gameObject.SetActive(false);
                player.MovePlayerBack();
            }
        }
    }//END OnTriggerEnter2D

}//END Class Obstacle
