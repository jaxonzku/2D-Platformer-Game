using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour

{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("collison");

        if (collision.gameObject.GetComponent<Player>() != null)
        {
            Debug.Log("player dead");
            SceneManager.LoadScene(0);
        }

    }
}
