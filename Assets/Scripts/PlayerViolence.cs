using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerViolence : MonoBehaviour
{
    // TODO: Pull stats from Rock - swing speed, aoe, throw area, throw speed
    // TODO: Implement hasRock checks
    // TODO: Implement throwing animations
    // TODO: Animations and timers
    // TODO: Collider selection (facing direction)
    // TODO: Conditions for changing state (in animator?)
    // TODO: Add collision/trigger script to colliders to splat things/register hit

    public bool hasRock;
    public bool isThrowing;
    public bool isAttacking;
    public float timer = 0;
    public float cooldown = 0.25f;
    
    public Collider2D colliderSide;
    public Collider2D colliderUp;
    public Collider2D colliderDown;

    public Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();    
    }

    void Update()
    {
        // Input
        // RMB
        // Single click because you can't spam-throw
        if (Input.GetMouseButtonDown(1))
        {
            
        }
        // LMB
        // Down for repeated swinging
        if (Input.GetMouseButton(0))
        {
            isAttacking = true;
        }
        else
        {
            isAttacking = false;
        }
    }

    private void FixedUpdate()
    {
        animator.SetBool("IsAttacking", isAttacking);
        colliderSide.enabled = isAttacking;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        print("I am slain.");
        Animator otherAnimator = other.GetComponent<Animator>();
        if (otherAnimator)
        {
            otherAnimator.Play("Enemy_Explode");
        }
    }
}
