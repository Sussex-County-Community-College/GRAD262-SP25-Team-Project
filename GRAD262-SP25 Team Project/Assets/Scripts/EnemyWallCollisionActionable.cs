using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SCCC
{

    public class EnemyWallCollisionActionable : Actionable
    {
        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
            EnemyManager.Instance.AddEnemy(gameObject.GetComponent<Enemy>());
        }

        public override void DoAction()
        {
            Debug.Log("enemy collided with wall");
            gameObject.GetComponent<Wander>().ReverseDirection();
        }

        private void OnDestroy()
        {
            EnemyManager.Instance.RemoveEnemy(gameObject.GetComponent<Enemy>());
        }
    }
}
