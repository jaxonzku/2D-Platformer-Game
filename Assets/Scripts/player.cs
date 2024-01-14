using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    // Start is called before the first frame update
    Animator animator;
    void Start()
    {
        animator=this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.DownArrow)) {
            animator.SetBool("crouch", true);
        }
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            animator.SetBool("crouch", false);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            animator.SetBool("jump", true);
        }
        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            animator.SetBool("jump", false);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            animator.SetFloat("speed", 0.3f);
        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            animator.SetFloat("speed", 0.24f);
        }

    }
}
