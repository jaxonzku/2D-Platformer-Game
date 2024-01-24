using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Animator animator;
    private float crouchOffset = 0.5f;
    private float crouchSize = 0.8f;
    private float jumpOffset = 1.4f;
    private float jumpSize = 1.1f;
    private BoxCollider2D playerCollider;
    private BoxCollider2D orginalCollider;

    private Vector2 originalSize;
    public float speed;
    private Rigidbody2D rb2d;
    public float jump;
    private string groundTag = "platform";
    public ScoreController scoreController;



    void Awake()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        playerCollider = GetComponent<BoxCollider2D>();
        orginalCollider = playerCollider;
        Debug.Log(playerCollider.offset.x);

    }

    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        PlayerMovementAnimation(horizontal,vertical);
        MoveCharacter(horizontal,vertical);
    }

    private void PlayerMovementAnimation(float horizontal,float vertical)
    {
        Vector3 scale = transform.localScale;
        animator.SetFloat("speed", Mathf.Abs(horizontal));

        if (horizontal < 0)
        {
            scale.x = -1f * Mathf.Abs(scale.x);
        }
        else if (horizontal > 0)
        {
            scale.x = Mathf.Abs(scale.x);
        }

        if (vertical < 0)
        {
            animator.SetBool("crouch", true);
            playerCollider.offset = new Vector2(playerCollider.offset.x, crouchOffset);
            playerCollider.size = new Vector2(playerCollider.size.x, crouchSize);

        }
        else if (vertical > 0 &&IsGrounded())
        {

            animator.SetBool("jump", true);
            playerCollider.offset = new Vector2(playerCollider.offset.x, jumpOffset);
            playerCollider.size = new Vector2(playerCollider.size.x, jumpSize);

        }
        else
        {
            animator.SetBool("crouch", false);
            animator.SetBool("jump", false);
            playerCollider.offset = new Vector2(playerCollider.offset.x, 1.0f);
            playerCollider.size = new Vector2(playerCollider.size.x, 2.0f);

        }
        transform.localScale = scale;

    }
    private void MoveCharacter(float horizontal,float vertical)
    {
        Vector3 position = transform.position;
        position.x = position.x + horizontal * speed * Time.deltaTime;
        transform.position=position;

        if(vertical> 0 && IsGrounded())
        {
           
         rb2d.AddForce(new Vector2(0f, jump), ForceMode2D.Impulse);

            
        }

    }

    bool IsGrounded()
    {
        // Check if the player is grounded based on the tag of the ground objects
        Collider2D[] colliders = Physics2D.OverlapBoxAll(playerCollider.bounds.center, playerCollider.bounds.size, 0f);

        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag(groundTag))
            {
                Debug.Log("grounded true");
                return true;
            }
        }
        Debug.Log("grounded false");
        return false;
    }

    public  void KeyPickUp()
    {
        Debug.Log("key picked up");
        scoreController.IncrementScore(10);
    }
}
