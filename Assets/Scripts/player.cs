using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public Animator animator;

    public float jumpOffset = 1.4f;
  public float jumpSize = 1.1f;
  private BoxCollider2D playerCollider;

    private Vector2 originalSize;
    public float speed;
    private Rigidbody2D rb2d;
    public float jump;

    public ScoreController scoreController;
    public GameOverController gameOverController;

    public Vector2 force = new Vector2(0f, 500f);
    public float castDistance;
    public Vector2 boxSize;
    public LayerMask groundLayer;

    void Awake()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        Debug.Log("awake");
    }
    void Start()
    {

    }

    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        PlayerMovementAnimation(horizontal, vertical);
        MoveCharacter(horizontal, vertical);
        IsGrounded();
    }
    private void PlayerMovementAnimation(float horizontal, float vertical)
    {
        Vector3 scale = transform.localScale;
        animator.SetFloat("speed", Mathf.Abs(horizontal));

        if (horizontal < 0)
        {
            scale.x = -1f* Mathf.Abs(scale.x);
        }
        else if (horizontal > 0)
        {
            scale.x = Mathf.Abs(scale.x);
        }

        if (vertical < 0)
        {
            animator.SetBool("crouch", true);

        }
  /*      else if (vertical > 0 && !IsGrounded())
        {
            animator.SetBool("jump", true);

        }*/
        else
        {
            animator.SetBool("crouch", false);
        /*    animator.SetBool("jump", false);*/

        }
        transform.localScale = scale;

    }

    bool IsGrounded()
    {
        if (Physics2D.BoxCast(transform.position, boxSize, 0, -transform.up, castDistance, groundLayer))
        {
            Debug.Log("is grounded");
            rb2d.gravityScale = 1f;
            return true;
        }
        else
        {
            Debug.Log("not grounded");
            rb2d.gravityScale = 2f;
            return false;
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawCube(transform.position - transform.up * castDistance, boxSize);
    }

    private void MoveCharacter(float horizontal, float vertical)
    {
        Vector3 position = transform.position;
        position.x = position.x + horizontal * speed * Time.deltaTime;
        transform.position = position;

        if (vertical > 0 && IsGrounded())
        {

            Debug.Log("jumping" + force * Time.deltaTime);
            animator.SetBool("jump", true);
            rb2d.velocity = new Vector2(rb2d.velocity.x, jump);

        }
        else
        {
            animator.SetBool("jump", false);

        }

    }

    public void KeyPickUp()
    {
        Debug.Log("key picked up");
        scoreController.IncrementScore(10);
    }

    public void KillPlayer()
    {
        Debug.Log("player Dead");
        gameOverController.PlayerDied();

    }

}