using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DracarysInteractive.AIStudio;
using UnityEngine.SceneManagement;
using System;

public class GameManager : Singleton<GameManager>
{
    HashSet<int> scenesLoaded = new HashSet<int>();

    private void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void ToggleEnemies()
    {
        Enemy[] enemies = GameObject.FindObjectsByType<Enemy>(FindObjectsSortMode.None);
        foreach(Enemy enemy in enemies)
        {
            enemy.gameObject.SetActive(!enemy.gameObject.activeInHierarchy);
        }
    }

    private void OnSceneLoaded(Scene arg0, LoadSceneMode arg1)
    {
        if (HasSceneBeenLoadedBefore())
            ToggleEnemies();
        scenesLoaded.Add(arg0.buildIndex);
    }

    public bool HasSceneBeenLoadedBefore()
    {
        return scenesLoaded.Contains(SceneManager.GetActiveScene().buildIndex);
    }
}
