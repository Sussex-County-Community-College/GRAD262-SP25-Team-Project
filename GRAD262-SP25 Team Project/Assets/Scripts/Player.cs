using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using SCCC;
using JetBrains.Annotations;

namespace SCCC
{
    public class Player : MonoBehaviour
    {
        public int currentHealth = StatManager.Instance.GetStat("CurrentHealth");
        public int maxHealth = StatManager.Instance.GetStat("MaxHealth");
        public int attackStat = StatManager.Instance.GetStat("AttackStat");
        public int defenseStat = StatManager.Instance.GetStat("DefenseStat");
        public int currentMana = StatManager.Instance.GetStat("CurrentMana");
        public int maxMana = StatManager.Instance.GetStat("MaxMana");
        // Start is called before the first frame update
        void Start()
        {
            // Initialize player stats from the Class Script that has an enum for the classes
            // Set default values for player stats
            StatManager.Instance.SetStat("CurrentHealth", 20, true);
            StatManager.Instance.SetStat("MaxHealth", 20, true);
            StatManager.Instance.SetStat("AttackStat", 10, true);
            StatManager.Instance.SetStat("DefenseStat", 10, true);
            StatManager.Instance.SetStat("CurrentMana", 10, true);
            StatManager.Instance.SetStat("MaxMana", 10, true);
            
        }

        // Update is called once per frame
        void Update()
        {

        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Enemy"))
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}