using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private static LevelManager instance;
    public static LevelManager Instance { get { return instance; } }
    public string Level1;
    public GameObject Explosion;

    public string[] Levels;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        } 

        
    }

    private void Start()
    {
        SetLevelStatus("Level1", LevelStatus.Unlocked);
        SetLevelStatus("Level2", LevelStatus.Locked);
        SetLevelStatus("Level3", LevelStatus.Locked);
        SetLevelStatus("Level4", LevelStatus.Locked);
    }

    public  LevelStatus GetLevelStatus(string level)
    {
        LevelStatus levelStatus=(LevelStatus) PlayerPrefs.GetInt(level);
        return levelStatus;

    }

    public void SetLevelStatus(string level,LevelStatus levelStatus)
    {
        PlayerPrefs.SetInt(level, (int)levelStatus);
    }

    public void MarkCurrentLevelComplete() {
       Scene scene = SceneManager.GetActiveScene();
       SetLevelStatus(scene.name, LevelStatus.Completed);
       int currentIndex = Array.FindIndex(Levels, Level=> Level == scene.name);
       int nextSceneIndex = currentIndex + 1;
       if (nextSceneIndex < Levels.Length)
        {
            SetLevelStatus(Levels[nextSceneIndex], LevelStatus.Unlocked);
        }
        
    }

}
