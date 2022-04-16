using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinTrigger : MonoBehaviour
{
    //---------------------------//
    void OnTriggerEnter2D(Collider2D collider)
    //---------------------------//
    {

        if (collider.tag == "Player")
        {
            Debug.Log("Ya did it");
            SceneManager.LoadScene(3);
        }

    }//END OnTriggerEnter2D


}//END WinTrigger
