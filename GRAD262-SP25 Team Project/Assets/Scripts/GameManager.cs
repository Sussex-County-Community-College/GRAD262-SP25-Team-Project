using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.Text.RegularExpressions;

namespace SCCC
{

    public class GameManager : MonoBehaviour
    {
        static public GameManager Instance;
        public bool enemiesSpawned = false;
        public List<Enemy> enemies = new List<Enemy>();
        public Transform[] enemySpawnPoints;
        public GameObject enemyPrefab;
        public Vector3 playerPosition;

        private void Awake()
        {
            if (Instance)
            {
                Destroy(gameObject);
            }
            else
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
        }

        private void Start()
        {
            SceneManager.sceneLoaded += OnSceneLoaded;

            if (isDungeonScene() && !enemiesSpawned)
                SpawnEnemies();
            else
                ToggleEnemies(isDungeonScene());
        }

        private void ToggleEnemies(bool active)
        {
            foreach (Enemy enemy in enemies)
            {
                enemy.gameObject.SetActive(active);
            }
        }

        private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            if (isDungeonScene() && !enemiesSpawned) 
                SpawnEnemies();
            else
                ToggleEnemies(isDungeonScene());
        }

        void SpawnEnemies()
        {
            for(int i = 0; i < enemySpawnPoints.Length; i++)
            {
                AddEnemy(Instantiate(enemyPrefab, enemySpawnPoints[i].position, Quaternion.identity).GetComponent<Enemy>());
            }
            enemiesSpawned = true;
        }

        private bool isDungeonScene()
        {
            return Regex.IsMatch(SceneManager.GetActiveScene().name, "dungeon", RegexOptions.IgnoreCase);
        }

        public void AddEnemy(Enemy enemy)
        {
            enemies.Add(enemy);
        }

        public void RemoveEnemy(Enemy enemy) 
        { 
            enemies.Remove(enemy);
        }
    }
}