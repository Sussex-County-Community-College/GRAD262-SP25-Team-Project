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
            else
                SpawnObject();
        }

        public GameObject SpawnObject()
        {

            if (prefabToSpawn != null)
            {
                GameObject go = Instantiate(prefabToSpawn, transform.position, Quaternion.identity);
                if (go.GetComponent<Enemy>())
                    GameManager.Instance.AddEnemy(go.GetComponent<Enemy>());
            }
            return null;
        }
    }
}
