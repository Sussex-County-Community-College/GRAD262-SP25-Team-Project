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
        }

        public override void DoAction()
        {
            Debug.Log("enemy collided with wall");
            gameObject.GetComponent<Wander>().ReverseDirection();
        }
    }
}
