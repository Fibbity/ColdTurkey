using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Obstacle : MonoBehaviour
{
    private PlayerMovement player { get; set; }

    void Awake()
    {
        player = GameObject.FindWithTag("Player").GetComponent<PlayerMovement>();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.tag == "Player")
        {
            if (!player.isInvincible)
            {
                gameObject.SetActive(false);
                player.MovePlayerBack();
            }
        }
    }
}
