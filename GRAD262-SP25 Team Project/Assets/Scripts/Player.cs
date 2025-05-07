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
#if false
        public int currentHealth;
        public int maxHealth;
        public int attackStat;
        public int defenseStat;
        public int currentMana;
        public int maxMana;
#endif

        // Start is called before the first frame update
        void Start()
        {
#if false
            // Initialize player stats from the Class Script that has an enum for the classes
            // Set default values for player stats
            StatManager.Instance.SetStat("CurrentHealth", 20, true);
            StatManager.Instance.SetStat("MaxHealth", 20, true);
            StatManager.Instance.SetStat("AttackStat", 10, true);
            StatManager.Instance.SetStat("DefenseStat", 10, true);
            StatManager.Instance.SetStat("CurrentMana", 10, true);
            StatManager.Instance.SetStat("MaxMana", 10, true);

            // why these fields?
            currentHealth = StatManager.Instance.GetStat("CurrentHealth");
            maxHealth = StatManager.Instance.GetStat("MaxHealth");
            attackStat = StatManager.Instance.GetStat("AttackStat");
            defenseStat = StatManager.Instance.GetStat("DefenseStat");
            currentMana = StatManager.Instance.GetStat("CurrentMana");
            maxMana = StatManager.Instance.GetStat("MaxMana");
#endif
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Enemy"))
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}