using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseScript : MonoBehaviour
{
    [SerializeField] private AudioSource aSource;
    [SerializeField] private Animator animator;
    [SerializeField] private AudioSource bgSource;


    public void Lose()
    {
        animator.SetBool("hasLost", true);
        bgSource.Stop();
    }

    public void Fire()
    {
        aSource.Play();
    }


    public void LoadLoseScene()
    {
        SceneManager.LoadScene(2);
    }

}
