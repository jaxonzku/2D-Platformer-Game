using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class HealthController : MonoBehaviour
{
    public int health = 3;
    public int numOfHearts;
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;
    public GameOverController gameOverController;
    public Animator animator;
    public GameObject Explosion;
    public Player player;

    void Update()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < numOfHearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }

            if (i < health)
            {
                hearts[i].sprite = fullHeart;

            }
            else
            {
                hearts[i].sprite = emptyHeart;

            }
        }
    }

    private IEnumerator DelayedFunctionCall(float delay)
    {
        yield return new WaitForSeconds(delay);
        gameOverController.PlayerDied();



    }

    public void Reducehealth()
    {
        health = health-1;
        if (health == 0)
        {
            Debug.Log("reducing h");
            /*SceneManager.LoadScene(0);*/
            animator.SetBool("dead", true);
            Instantiate(Explosion, player.transform.position, Quaternion.identity);
            StartCoroutine(DelayedFunctionCall(2f));

        }

    }



}
