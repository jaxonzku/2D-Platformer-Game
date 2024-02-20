using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverController : MonoBehaviour
{
    public Button Restartbutton;
    public Button Quitbutton;


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
        SceneManager.LoadScene(1);
    }
    private void LobbyScene()
    {
        SceneManager.LoadScene(0);
    

    }

}
