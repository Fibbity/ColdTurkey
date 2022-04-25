using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadGameScene : MonoBehaviour
{
    [SerializeField] private MainMenuManager main;

    public void Load()
    {

        main.LoadScene();
    }
}
