using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    private string CurrentLevelName = string.Empty;

    public GameObject SelectMenu;

    public string curName = "MainMenu";
    Scene currentScene;

    void Awake() {
        Scene currentScene = SceneManager.GetActiveScene();
        curName = currentScene.name;
    }
    public void LoadLevel(string levelName)
    {
        AsyncOperation ao = SceneManager.LoadSceneAsync(levelName, LoadSceneMode.Additive);
        if (ao == null)
        {
            Debug.LogError("[GameManager] Unable to load level");
            return;
        }
        CurrentLevelName = levelName;
        curName = levelName;
    }

    public void UnloadLevel(string levelName)
    {
        AsyncOperation ao = SceneManager.UnloadSceneAsync(levelName);
        if (ao == null)
        {
            Debug.LogError("[GameManager] Unable to unload level");
            return;
        }
        CurrentLevelName = levelName;
        curName = "MainMenu";
    }

    private void Update()
    {
       // currentScene = SceneManager.GetActiveScene();
        //curName = currentScene.name;

        if (Input.GetKeyDown(KeyCode.P))
        {    
            if (curName != "MainMenu")
            {
                UnloadCurrentLevel();
                SelectMenu.SetActive(true);
                curName = "MainMenu";
            }
            else { 
            
            }
        }

    }

    public void UnloadCurrentLevel()
    {
        AsyncOperation ao = SceneManager.UnloadSceneAsync(CurrentLevelName);
        if (ao == null)
        {
            Debug.LogError("[GameManager] Unable to unload level");
            return;
        }
    }
}
