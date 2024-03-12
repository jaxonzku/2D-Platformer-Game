using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


[RequireComponent(typeof(Button))]
public class LevelLoader : MonoBehaviour
{

    private Button button;
    public string LevelName;
    private void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(onClick);
    }

    private void onClick()
    {

        LevelStatus levelStatus = LevelManager.Instance.GetLevelStatus(LevelName);
        Debug.Log("levelsatus" + levelStatus +"levelname :"+LevelName);
        switch (levelStatus)
        {
            case LevelStatus.Locked:
                Debug.Log("THE LEVEL IS LOCKED");
                SoundManager.Instance.Play(Sounds.ButtonClick);
                break;
            case LevelStatus.Unlocked:
                SceneManager.LoadScene(LevelName);
                break;
            case LevelStatus.Completed:
                SceneManager.LoadScene(LevelName);
                break;
        }
      
        
    }

}
