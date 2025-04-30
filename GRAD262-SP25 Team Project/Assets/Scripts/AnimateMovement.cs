using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateMovement : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rb;

    void Awake()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Vector2 velocity = rb.velocity;

        // Speed as magnitude of velocity
        float speed = velocity.magnitude;

        // Normalize for direction (avoid NaN if velocity is zero)
        Vector2 direction = velocity.normalized;

        animator.SetFloat("Speed", speed);
        animator.SetFloat("MoveX", direction.x);
        animator.SetFloat("MoveY", direction.y);
    }
}
