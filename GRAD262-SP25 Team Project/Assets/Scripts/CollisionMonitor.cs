using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionMonitor : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Actionable actionable = collision.gameObject.GetComponent<Actionable>();
        if (actionable)
            actionable.DoAction();
    }
}
