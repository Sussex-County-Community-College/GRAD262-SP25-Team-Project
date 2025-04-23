using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using SCCC;

namespace SCCC
{
    public class Player : MonoBehaviour
    {
        public StatManager statManager;
        public Class classManager;

        // Start is called before the first frame update
        void Start()
        {
            statManager = FindObjectOfType<StatManager>();
            classManager = FindObjectOfType<Class>();

            if (statManager == null)
            {
                Debug.LogError("StatManager not found in the scene.");
                return;
            }

            if (classManager == null)
            {
                Debug.LogError("ClassManager not found in the scene.");
                return;
            }

            // Initialize player stats
            statManager.SetStat("CurrentHealth", 20, true);
            statManager.SetStat("MaxHealth", 20, true);
            statManager.SetStat("CurrentClass", (int)ClassType.Knight, true); // Default class
            statManager.SetStat("AttackStat", 10, true);
            statManager.SetStat("DefenseStat", 10, true);
            statManager.SetStat("CurrentMana", 10, true);
            statManager.SetStat("MaxMana", 10, true);
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