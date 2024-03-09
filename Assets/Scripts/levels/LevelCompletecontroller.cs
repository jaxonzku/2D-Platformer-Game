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

    private void OnTriggerEnter2D(Collider2D collision)
    {

        Debug.Log("collison");

        if (collision.gameObject.GetComponent<Player>() != null)
        {
            Debug.Log("Level Complete");
            LevelManager.Instance.MarkCurrentLevelComplete();
            Debug.Log("flaf1");
            banner.GetComponentInChildren<LevelCompleteUi>().gameObject.SetActive(true);

            
        


        }

    }
}
