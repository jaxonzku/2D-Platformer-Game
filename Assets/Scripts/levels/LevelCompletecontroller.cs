using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelCompletecontroller : MonoBehaviour
{
    public GameObject banner;
    public GameObject Explosion;

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void HomeScreen()
    {
        SceneManager.LoadScene(0);
    }
    private void DelayedFunctionCallAfterLevelcomplete()
    {
        LevelManager.Instance.MarkCurrentLevelComplete();
        banner.GetComponentInChildren<LevelCompleteUi>().gameObject.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Player>() != null)
        {
            Instantiate(Explosion, transform.position, Quaternion.identity);
            Invoke("DelayedFunctionCallAfterLevelcomplete", 1f);
        }

    }
}
