using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DracarysInteractive.AIStudio;
using UnityEngine.SceneManagement;
using System;
using System.Text.RegularExpressions;

public class GameManager : Singleton<GameManager>
{
    public bool enemiesSpawned = false;

    private void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        ToggleEnemies(isDungeonScene());
    }

    private void ToggleEnemies(bool active)
    {
        Enemy[] enemies = Resources.FindObjectsOfTypeAll<Enemy>();
        foreach (Enemy enemy in enemies)
        {
            enemy.gameObject.SetActive(active);
        }
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        ToggleEnemies(isDungeonScene());
    }

    private bool isDungeonScene()
    {
        return Regex.IsMatch(SceneManager.GetActiveScene().name, "dungeon", RegexOptions.IgnoreCase);
    }

    public bool EnemiesSpawned()
    {
        if (!enemiesSpawned)
        {
            enemiesSpawned = GameObject.FindObjectsByType<Enemy>(FindObjectsSortMode.None).Length > 0;
        }

        return enemiesSpawned;
    }
}
