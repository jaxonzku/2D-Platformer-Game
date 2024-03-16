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

     /*   if (GetLevelStatus(Levels[0]) == LevelStatus.Locked)
            Debug.Log("initial : " + Levels[0] + " status==" + GetLevelStatus(Levels[0]));
        {
            SetLevelStatus(Levels[0], LevelStatus.Unlocked);

        }*/
        Debug.Log("0" + GetLevelStatus(Levels[0]));
        Debug.Log("1" + GetLevelStatus(Levels[1]));
        Debug.Log("2" + GetLevelStatus(Levels[2]));
        Debug.Log("3" + GetLevelStatus(Levels[3]));
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
        Debug.Log("setting level: " + level + "as " + levelStatus);
        PlayerPrefs.SetInt(level, (int)levelStatus);
    }

    public void MarkCurrentLevelComplete() {


        Debug.Log("hit");
   
        Scene scene = SceneManager.GetActiveScene();
       SetLevelStatus(scene.name, LevelStatus.Completed);
        /*       int nextSceneIndex=scene.buildIndex + 1;
              Scene nextScene = SceneManager.GetSceneByBuildIndex(nextSceneIndex);
              SetLevelStatus("level"+nextScene.buildIndex.ToString(), LevelStatus.Unlocked);*/
        Debug.Log("currentsceeeen" + scene.name);
        int currentIndex = Array.FindIndex(Levels, Level=> Level == scene.name);
        Debug.Log("currrrrrentIndex" + currentIndex);
        int nextSceneIndex = currentIndex + 1;
        Debug.Log("nextseceenindex" + nextSceneIndex);

        if (nextSceneIndex < Levels.Length)
        {
            Debug.Log("nexttt setting" + nextSceneIndex);
            SetLevelStatus(Levels[nextSceneIndex], LevelStatus.Unlocked);
        }


    }

}
