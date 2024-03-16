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
        // Wait for the specified delay
        yield return new WaitForSeconds(delay);

        // Call the example function after the delay
        Debug.Log("calling after delay");

        LevelManager.Instance.MarkCurrentLevelComplete();
        banner.GetComponentInChildren<LevelCompleteUi>().gameObject.SetActive(true);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        Debug.Log("collison");

        if (collision.gameObject.GetComponent<Player>() != null)
        {
            Debug.Log("Level Complete");
            Instantiate(Explosion, transform.position, Quaternion.identity);
            StartCoroutine(DelayedFunctionCall(1f));  }

    }
}
