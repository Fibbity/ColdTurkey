using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerY : MonoBehaviour
{
    public GameObject Player;

    void Update()
    {
        transform.position = new Vector2(transform.position.x, Player.transform.position.y);
    }
}
//This script is pointless