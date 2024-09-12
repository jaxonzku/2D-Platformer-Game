using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KeyController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("collison key");

        if (collision.gameObject.GetComponent<Player>() != null)
        {
            Player player=collision.gameObject.GetComponent<Player>();
            player.KeyPickUp();
            Debug.Log("key picked");
            Destroy(gameObject);
        }

    }
}