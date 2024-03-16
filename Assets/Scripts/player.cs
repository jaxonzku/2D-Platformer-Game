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
    public GameObject Explosion;

    void Awake()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
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
            scale.x = Mathf.Abs(scale.x) * -1f;
            animator.SetBool("running", true);
        }
        else if (horizontal > 0)
        {
            scale.x = Mathf.Abs(scale.x);
            animator.SetBool("running", true);
        }
        else {
            animator.SetBool("running", false);
        }

        if (vertical < 0)
        {
            /*Debug.Log("verticlal "+vertical);*/
            animator.SetBool("crouch", true);
            animator.SetBool("jump", false); // Reset jump animation when crouching
        }
        else if (vertical > 0)
        {
            animator.SetBool("crouch", false);
            animator.SetBool("jump", true);
            animator.SetBool("running", false);
        }
        else
        {
            animator.SetBool("crouch", false);
        }

        transform.localScale = scale;
    }


    bool IsGrounded()
    {
        if (Physics2D.BoxCast(transform.position, boxSize, 0, -transform.up, castDistance, groundLayer))
        {

            rb2d.gravityScale = 1f;
            animator.SetBool("jump", false);

            /*animator.SetBool("jump", false)*/

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

            Debug.Log("setting jump true",animator);
/*            animator.SetBool("jump", true)*/
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