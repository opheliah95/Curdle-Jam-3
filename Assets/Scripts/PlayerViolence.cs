using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerViolence : MonoBehaviour
{
    // TODO: Pull stats from Rock - swing speed, aoe, throw area, throw speed
    // TODO: Fill in that skeleton
    // TODO: Animations and timers

    public bool isThrowing;
    public bool isAttacking;
    public float cooldown = 0.25f;

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
            RockThrow();
        }
        // LMB
        // Down for repeated swinging
        if (Input.GetMouseButton(0))
        {
            isAttacking = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            isAttacking = false;
        }
    }

    private void FixedUpdate()
    {
        // Using input
        // Eh...animator handles?
        animator.SetBool("IsAttacking", isAttacking);
    }

    void RockThrow()
    {
        print("I throw the stone.");
    }

    void RockSmash()
    {
        print("Swing and a....");
    }
}
