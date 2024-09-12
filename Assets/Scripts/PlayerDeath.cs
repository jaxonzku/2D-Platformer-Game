using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour

{
    public HealthController healthController;
    public Player PlayerController;
    public Animator animator;



    private IEnumerator DelayedFunctionCall(float delay)
    {
        yield return new WaitForSeconds(delay);
        PlayerController.KillPlayer();


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("collison");

        if (collision.gameObject.GetComponent<Player>() != null)
        {
            Debug.Log("player dead");

/*            healthController.health = 0;*/
            animator.SetBool("dead", true);

            StartCoroutine(DelayedFunctionCall(2f));


            /*SceneManager.LoadScene(0);*/
        }

    }


}
