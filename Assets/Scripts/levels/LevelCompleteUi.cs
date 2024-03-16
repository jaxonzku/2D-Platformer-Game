using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelCompleteUi : MonoBehaviour
{
    public Button Restartbutton;
    public Button Quitbutton;



    private void Awake()
    {
        Restartbutton.onClick.AddListener(ReloadScene);
        Quitbutton.onClick.AddListener(LobbyScene);

    }
    private void ReloadScene()
    {
        Debug.Log("clicking");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    private void LobbyScene()
    {
        Debug.Log("home click");
        SceneManager.LoadScene(0);


    }
}
