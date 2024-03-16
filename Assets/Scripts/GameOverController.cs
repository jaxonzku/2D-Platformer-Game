using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverController : MonoBehaviour
{
    public Button Restartbutton;
    public Button Quitbutton;
    public Animator animator;


    private void Awake()
    {
     Restartbutton.onClick.AddListener(ReloadScene);
     Quitbutton.onClick.AddListener(LobbyScene);

    }
  
    public void PlayerDied()
    {
       
        gameObject.SetActive(true);

    }
    private void ReloadScene()
    {
        Debug.Log("clicking");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    private void LobbyScene()
    {
        SceneManager.LoadScene(0);
    

    }

}
