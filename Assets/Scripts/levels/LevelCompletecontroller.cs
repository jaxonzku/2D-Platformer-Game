using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelCompletecontroller : MonoBehaviour
{
    public GameObject banner;
    public Button Restartbutton;
    public Button HomeButton;
    public GameObject Explosion;

    private void Awake()
    {
        Restartbutton.onClick.AddListener(ReloadScene);
        HomeButton.onClick.AddListener(HomeScreen);

    }
    private void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    private void HomeScreen()
    {
        SceneManager.LoadScene(0);


    }
    private IEnumerator DelayedFunctionCall(float delay)
    {
        yield return new WaitForSeconds(delay);
        LevelManager.Instance.MarkCurrentLevelComplete();
        banner.GetComponentInChildren<LevelCompleteUi>().gameObject.SetActive(true);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Player>() != null)
        {
            Instantiate(Explosion, transform.position, Quaternion.identity);
            StartCoroutine(DelayedFunctionCall(1f));  }

    }
}
