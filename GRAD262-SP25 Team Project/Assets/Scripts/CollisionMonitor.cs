using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionMonitor : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Actionable[] actionables = collision.gameObject.GetComponents<Actionable>();
        foreach (Actionable actionable in actionables)
            actionable.DoAction();
    }
}
