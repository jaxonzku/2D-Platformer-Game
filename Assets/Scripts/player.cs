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
    public float speed;
    private Rigidbody2D rb2d;
    public float jump;
    public ScoreController scoreController;
    public GameOverController gameOverController;
    public Vector2 force = new Vector2(0f, 500f);
    public float castDistance;
    public Vector2 boxSize;
    public LayerMask groundLayer;
    public GameObject Explosion;

    private void Awake()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
    }

    private void Update()
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
        animator.SetFloat(StringConstants.animatePlayerSpeed, Mathf.Abs(horizontal));

        if (horizontal < 0)
        {
            scale.x = Mathf.Abs(scale.x) * -1f;
            animator.SetBool(StringConstants.animatePlayerRunning, true);
        }
        else if (horizontal > 0)
        {
            scale.x = Mathf.Abs(scale.x);
            animator.SetBool(StringConstants.animatePlayerRunning, true);
        }
        else
        {
            animator.SetBool(StringConstants.animatePlayerRunning, false);
        }

        if (vertical < 0)
        {
            animator.SetBool(StringConstants.animatePlayerCrouch, true);
            animator.SetBool(StringConstants.animatePlayerJump, false); 
        }
        else if (vertical > 0)
        {
            animator.SetBool(StringConstants.animatePlayerCrouch, false);
            animator.SetBool(StringConstants.animatePlayerJump, true);
            animator.SetBool(StringConstants.animatePlayerRunning, false);
        }
        else
        {
            animator.SetBool("crouch", false);
        }

        transform.localScale = scale;
    }

    private bool IsGrounded()
    {
        if (Physics2D.BoxCast(transform.position, boxSize, 0, -transform.up, castDistance, groundLayer))
        {

            rb2d.gravityScale = 1f;
            animator.SetBool("jump", false);
            return true;
        }
        else
        {
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
            rb2d.velocity = new Vector2(rb2d.velocity.x, jump);
        }
    
    }
    public void KeyPickUp()
    {
        scoreController.IncrementScore(10);
        Instantiate(Explosion, transform.position, Quaternion.identity);
    }

    public void KillPlayer()
    {
        gameOverController.PlayerDied();
    }

}