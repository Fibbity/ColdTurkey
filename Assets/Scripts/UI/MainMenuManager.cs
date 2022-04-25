using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{

    [SerializeField] private Animator fadeAnimator;
    [SerializeField] private GameObject menu;

    //---------------------------//
    public void Menu(int value)
    //---------------------------//
    {
        if (value == 0)
        {
            fadeAnimator.SetBool("isStarting", true);
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

    //---------------------------//
    public void LoadScene()
    //---------------------------//
    {
        menu.SetActive(false);
        SceneManager.LoadScene(1);

    }//END LoadScene


}