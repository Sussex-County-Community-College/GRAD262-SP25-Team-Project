using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SCCC
{
    public class Barrel : MonoBehaviour
    {
        public float minKillVelocity = 1;

        private void OnCollisionEnter2D(Collision2D collision)
        {
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            if (enemy && gameObject.GetComponent<Rigidbody2D>().velocity.magnitude > minKillVelocity)
            {
                EnemyManager.Instance.RemoveEnemy(enemy);
                Destroy(enemy.gameObject);
                Destroy(gameObject);
            }
        }
    }
}