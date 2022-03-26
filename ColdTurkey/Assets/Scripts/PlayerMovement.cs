using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;
using Debug = UnityEngine.Debug;

public class PlayerMovement : MonoBehaviour
{
    private Animator animator;
    public PauseMenu pauseMenu;

    [SerializeField]
    private LayerMask platformsLayerMask;
    private Rigidbody2D rigidbody2d;
    private BoxCollider2D boxCollider2d;
    private string currentScene;
    private bool canDoubleJump = false;

    [SerializeField]
    private  GameObject healthTransformsParent;
    private Transform[] healthTransforms;
    public static int currentHealth = 0;
    public bool isInvincible;
    [SerializeField]
    private float invincibleDelay = 2.0f;
    private bool shouldLerp = false;
    private float elapsedTime = 0;

    [SerializeField]
    private float jumpVelocity = 0.1f;
    private float dragDistance;


    // Start is called before the first frame update
    void Awake()
    {
        animator = GetComponentInChildren<Animator>();

        currentScene = SceneManager.GetActiveScene().name;

        rigidbody2d = transform.GetComponent<Rigidbody2D>();
        boxCollider2d = transform.GetComponent<BoxCollider2D>();

        healthTransforms = healthTransformsParent.GetComponentsInChildren<Transform>();
        transform.position = healthTransforms[currentHealth].transform.position;

        dragDistance = Screen.height * 15 / 100;
    }

    // Update is called once per frame
    void Update()
    {
        if (IsGrounded())
        {
            animator.SetInteger("isJumping", 0);

            canDoubleJump = true;
        }
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
                Debug.Log(ex);
                transform.position = Vector3.Lerp(transform.position, healthTransforms[healthTransforms.Length - 1].transform.position, perc);
            }
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    private bool IsGrounded()
    {
        RaycastHit2D raycastHit2d = Physics2D.BoxCast( boxCollider2d.bounds.center, boxCollider2d.bounds.size, 0f, Vector2.down, 0.1f, platformsLayerMask );
        return raycastHit2d.collider != null;
    }

    private bool BeganTouch()
    {
        if (Input.GetTouch(0).phase == TouchPhase.Began)
        {
            return true;
        }
        return false;
    }

    public void MovePlayerBack()
    {
        isInvincible = true;
        shouldLerp = true;
        Debug.Log("Move player back fired.");
        currentHealth++;
        StartCoroutine(Invincible());
    }

    private IEnumerator Invincible()
    {
        yield return new WaitForSeconds(invincibleDelay);
        isInvincible = false;
        //shouldLerp = false;                                       //added this in because shouldLerp is never made false, which makes it so the player is always lerping
    }

    public void MovePlayerForward()
    {
        UnityEngine.Debug.Log("Move player forward fired.");
        if (currentHealth == 0)
        {
            return;
        }

        //col.transform.gameObject.SetActive(false);
        
        //transform.position = healthTransforms[currentHealth].transform.position;
        transform.position = Vector2.MoveTowards(transform.position, healthTransforms[currentHealth - 1].transform.position, invincibleDelay * Time.deltaTime);
        currentHealth--;
    }

    private void Jump()
    {
        animator.SetInteger("isJumping", 1);
        rigidbody2d.velocity = Vector2.up * jumpVelocity;
    }
}
