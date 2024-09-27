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

    public void Reducehealth()
    {
        health = health-1;
        if (health == 0)
        {
            Debug.Log("reducing h");
            gameOverController.PlayerDied();
            /*SceneManager.LoadScene(0);*/

        }

    }



}
