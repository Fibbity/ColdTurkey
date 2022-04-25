using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class WinScript : MonoBehaviour
{

    [SerializeField] private Animator animator;

    public void Win()
    {
        animator.SetBool("hasWon", true);
    }
    public void LoadScene()
    {
        SceneManager.LoadScene(3);
    }
}
