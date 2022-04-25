using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{


    #region Components


    [Header("Components")]
    [SerializeField] private LoseScript loseScript;
    [SerializeField] private SideScroll playerScroll;

    
    [SerializeField] private float deadWaitTime;

    [SerializeField] private Animator animator;

    [SerializeField] private LayerMask platformsLayerMask;

    [SerializeField] private Rigidbody2D rigidbody2d;

    [SerializeField] private BoxCollider2D boxCollider2d;



    private bool canDoubleJump = false;

    [SerializeField] private GameObject healthTransformsParent;

    private Transform[] healthTransforms;

    public static int currentHealth = 0;

    public bool isInvincible;
    [SerializeField] private float invincibleDelay = 2.0f;
    private bool shouldLerp = false;
    private float elapsedTime = 0;

    [SerializeField] private float jumpVelocity = 0.1f;
    [SerializeField] private float dragDistance;


    #endregion Components


    //---------------------------//
    void Start()
    //---------------------------//
    {
        animator = GetComponentInChildren<Animator>();

        rigidbody2d = transform.GetComponent<Rigidbody2D>();
        boxCollider2d = transform.GetComponent<BoxCollider2D>();

        healthTransforms = healthTransformsParent.GetComponentsInChildren<Transform>();
        transform.position = healthTransforms[currentHealth].transform.position;

        dragDistance = Screen.height * 15 / 100;

        animator.SetBool("isHealthy", true);


    }//END Start

    //---------------------------//
    void Update()
    //---------------------------//
    {
        //if (IsGrounded())
        //{
        //    animator.SetInteger("isJumping", 0);

        //    canDoubleJump = true;
        //}
        if (Input.touchCount > 0)
        {
            if (IsGrounded() && BeganTouch())
            {
                Jump();
            }
            if (!IsGrounded() && BeganTouch())
            {
                if (canDoubleJump)
                {
                    Jump();
                    canDoubleJump = false;
                }
            }
        }        

        if (IsGrounded() && Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
        if (!IsGrounded() && Input.GetKeyDown(KeyCode.Space))
        {
            if (canDoubleJump)
            {
                Jump();
                canDoubleJump = false;
            }
        }
        if (shouldLerp)
        {
            elapsedTime += Time.time;
            float perc = elapsedTime / invincibleDelay;

            try
            {
                //transform.position = Vector2.Lerp(transform.position, healthTransforms[currentHealth + 1].transform.position, perc);
                transform.position = Vector2.MoveTowards(transform.position, healthTransforms[currentHealth + 1].transform.position, invincibleDelay * Time.deltaTime);
            }
            catch(Exception ex)
            {
                loseScript.Lose();
                Debug.Log(ex);
                transform.position = Vector3.Lerp(transform.position, healthTransforms[healthTransforms.Length - 1].transform.position, perc);
            }
        }
        if (Input.GetKeyDown(KeyCode.Escape)) //QUIT FUNC
        {
            Application.Quit();
        }

    }//END Update

    //---------------------------//
    private bool IsGrounded()
    //---------------------------//
    {
        RaycastHit2D raycastHit2d = Physics2D.BoxCast( boxCollider2d.bounds.center, boxCollider2d.bounds.size, 0f, Vector2.down, 0.1f, platformsLayerMask );
        return raycastHit2d.collider != null;
    }//END IsGrounded

    //---------------------------//
    private bool BeganTouch()
    //---------------------------//
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            return true;
        }
        return false;
    }//END BeganTouch

    //---------------------------//
    public void MovePlayerBack() //A damage function
    //---------------------------//
    {
        animator.SetBool("isHealthy", false);
        isInvincible = true;
        shouldLerp = true;
        Debug.Log("Move player back fired.");
        currentHealth++;
        StartCoroutine(IInvincible());
    }//MovePlayerBack

    //---------------------------//
    private IEnumerator IInvincible()
    //---------------------------//
    {
        yield return new WaitForSeconds(invincibleDelay);
        isInvincible = false;
        animator.SetBool("isHealthy", true);

    }//END IInvincible

    //---------------------------//
    public void MovePlayerForward()
    //---------------------------//
    {
        Debug.Log("Move player forward fired.");
        if (currentHealth == 0)
        {
            loseScript.Lose();
            playerScroll.speed = 0.25f;
            return;
        }

        //col.transform.gameObject.SetActive(false);

        //transform.position = healthTransforms[currentHealth].transform.position;
        try
        {
            transform.position = Vector2.MoveTowards(transform.position, healthTransforms[currentHealth - 1].transform.position, invincibleDelay * Time.deltaTime);
            currentHealth--;

        }
        catch
        {
            if (healthTransforms[currentHealth] == null)
            {
                loseScript.Lose();
            }
            if (healthTransforms[currentHealth - 1] == null)
            {
                loseScript.Lose();
            }
        }

    }//END MovePlayerForward

    //---------------------------//
    private void Jump()
    //---------------------------//
    {
        //animator.SetInteger("isJumping", 1);
        rigidbody2d.velocity = Vector2.up * jumpVelocity;
    }//END Jump


}//END PlayerMovement
