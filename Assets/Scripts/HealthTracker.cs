using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HealthTracker : MonoBehaviour
{
    [SerializeField] private AudioSource playerSource;
    [SerializeField] private AudioClip[] damageClips;
    [SerializeField] private Animator animator;

    [Header("Text")]
    [SerializeField] private string[] lines;
    [SerializeField] private TMP_Text text;

    [Header("Health")]
    [SerializeField] private GameObject hp1;
    [SerializeField] private GameObject hp2;
    [SerializeField] private GameObject hp3;
    [SerializeField] private GameObject hp4;
    [SerializeField] private GameObject hp5;

    public int currentHP = 5;


    public void LoseHealth()
    {
        if (currentHP == 5)
        {
            currentHP--;
            hp5.SetActive(false);
        }
        else if (currentHP == 4)
        {
            currentHP--;
            hp4.SetActive(false);
        }
        else if (currentHP == 3)
        {
            currentHP--;
            hp3.SetActive(false);
        }
        else if (currentHP == 2)
        {
            currentHP--;
            hp2.SetActive(false);
        }
        else if (currentHP == 1)
        {
            currentHP--;
            hp1.SetActive(false);
        }
        TakeDamage();
    }

    void TakeDamage()
    {
        int i = Random.Range(0, lines.Length);
        int g = Random.Range(0, damageClips.Length);
        text.text = lines[i];

        playerSource.PlayOneShot(damageClips[g]);
        animator.SetBool("isOn", true);


    }//END TakeDamage;

    public void CloseText()
    {
        animator.SetBool("isOn", false);
    }
}
