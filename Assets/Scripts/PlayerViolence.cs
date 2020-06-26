using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerViolence : MonoBehaviour
{
    // TODO: Pull stats from Rock - swing speed, aoe, throw area, throw speed
    // TODO: Implement hasRock checks
    // TODO: Implement throwing animations
    // TODO: Animations and timers
    // TODO: Bugfix: jank on diagonal movement; if direction is diagonal, will sometimes attack in the direction you're not facing
    // TODO: Animation jank; Bottlenecked by art assets

    public bool hasRock;
    public bool isThrowing;
    public bool isAttacking;
    public float timer = 0;
    public float cooldown = 0.25f;

    public Collider2D rockSmashCollider;

    public Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();    
    }

    void Update()
    {
        if (hasRock)
        {
            // There's gotta be a simpler way, but fuck it, mad at git, can't be bothered.

            // Input
            // RMB
            // Single click because you can't spam-throw
            // Also throw will take precedence.
            if (Input.GetMouseButtonDown(1))
            {
                isThrowing = true;
                isAttacking = false;
            }
            // LMB
            // Down for repeated swinging
            else if (Input.GetMouseButton(0))
            {
                isAttacking = true;
                isThrowing = false;
            }
            else
            {
                isAttacking = false;
                isThrowing = false;
            }
        }
    }

    private void FixedUpdate()
    {
        animator.SetBool("IsThrowing", isThrowing);
        animator.SetBool("IsAttacking", isAttacking);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // TODO: Handle in mob script
        print("I am slain.");
        Animator otherAnimator = other.GetComponent<Animator>();
        if (otherAnimator)
        {
            otherAnimator.Play("Enemy_Explode");
        }
    }
}
