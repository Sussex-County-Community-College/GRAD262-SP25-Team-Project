using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonDoorCollision : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log($"{collision.gameObject.name} collided with dungeon door...");
        if (collision.gameObject.CompareTag("Barrel"))
        {
            BarrelCollision(collision.gameObject);
        }
    }

    private void BarrelCollision(GameObject gameObject)
    {
        Destroy(gameObject);
    }
}
