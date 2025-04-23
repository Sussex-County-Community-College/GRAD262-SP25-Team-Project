using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using SCCC;

namespace SCCC
{
    public class Player : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            // Initialize player stats
            StatManager.Instance.SetStat("CurrentHealth", 20, true);
            StatManager.Instance.SetStat("MaxHealth", 20, true);
            StatManager.Instance.SetStat("CurrentClass", (int)ClassType.Knight, true); // Default class
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