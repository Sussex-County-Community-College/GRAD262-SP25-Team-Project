using System;
using UnityEngine;

namespace SCCC
{
    public class SpawnPoint : MonoBehaviour
    {
        public GameObject prefabToSpawn;
        public float repeatInterval;

        public void Awake()
        {
            if (repeatInterval > 0)
            {
                InvokeRepeating("SpawnObject", 0.0f, repeatInterval);
            }
            else if(!GameManager.Instance.EnemiesSpawned())
                SpawnObject();
        }

        public GameObject SpawnObject()
        {

            if (prefabToSpawn != null)
            {
                return Instantiate(prefabToSpawn, transform.position, Quaternion.identity);
            }
            return null;
        }
    }
}
