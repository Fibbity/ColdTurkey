using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{

    //---------------------------//
    public void Menu(int value)
    //---------------------------//
    {
        if (value == 0)
        {
            SceneManager.LoadScene(1);
        }
        else
        {
            #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
            #else
            Application.Quit();
            #endif     
        }
    }
}