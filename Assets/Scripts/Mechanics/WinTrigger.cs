using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinTrigger : MonoBehaviour
{

    [SerializeField] WinScript winScript;
    //---------------------------//
    void OnTriggerEnter2D(Collider2D collider)
    //---------------------------//
    {

        winScript.Win();

    }//END OnTriggerEnter2D


}//END WinTrigger
