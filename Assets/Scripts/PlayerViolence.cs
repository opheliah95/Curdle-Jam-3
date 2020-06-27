using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerViolence : MonoBehaviour
{
    // TODO: Pull stats from Rock - swing speed, aoe, throw area, throw speed
    // TODO: Implement hasRock checks
    // TODO: Implement throwing animations
    // TODO: Animations and timers
    // TODO: Conditions for changing state (in animator?)
    // TODO: Add collision/trigger script to colliders to splat things/register hit
    // TODO: Bugfix: jank on diagonal movement; if direction is diagonal, will sometimes attack in the direction you're not facing
    // TODO: Animation jank; Bottlenecked by art assets

    public GameObject aRock;

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
        // Input
        // RMB
        // Single click because you can't spam-throw
        if (Input.GetMouseButtonDown(1))
        {
            GameObject.Instantiate(aRock, transform.position, new Quaternion(1, 1, 1, 1));
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
        // handled in animator
        //rockSmashCollider.enabled = isAttacking;
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
