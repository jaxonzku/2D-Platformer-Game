using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Animator animator;
    private float crouchOffset = 0.5f;
    private float crouchSize = 0.8f;


    private BoxCollider2D playerCollider;
    private Vector2 originalSize;



    void Start()
    {
        playerCollider = GetComponent<BoxCollider2D>();
        originalSize = playerCollider.offset;
    }

    void Update()
    {
        float speed = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 scale=transform.localScale;
        animator.SetFloat("speed", Mathf.Abs(speed));

        if (speed < 0)
        {
            scale.x = -1f * Mathf.Abs(scale.x);
        }
        else if (speed>0){
            scale.x=Mathf.Abs(scale.x);
        }

        if(vertical<0){
            animator.SetBool("crouch", true);
            playerCollider.offset= new Vector2(playerCollider.offset.x, crouchOffset);
            playerCollider.size = new Vector2(playerCollider.size.x, crouchSize);

        }
        else if (vertical > 0)
        {
            animator.SetBool("jump", true);

        }
        else
        {
            animator.SetBool("crouch", false);
            animator.SetBool("jump", false);
            playerCollider.offset = new Vector2(playerCollider.offset.x, playerCollider.offset.y);
            playerCollider.size = new Vector2(playerCollider.size.x, playerCollider.size.y);

        }
        transform.localScale = scale;
    }
}
