﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerViolence : MonoBehaviour
{
    // TODO: Pull stats from Rock - swing speed, aoe, throw area, throw speed
    // TODO: Implement throwing animations
    // TODO: Animations and timers
    // TODO: Bugfix: jank on diagonal movement; if direction is diagonal, will sometimes attack in the direction you're not facing
    // TODO: Animation jank; Bottlenecked by art assets
    // TODO: Rockless attack attempts
    // TODO: Pick up rock
    // TODO: Offset rock's start pos based on sprite + anim
    // TODO: Animation triggers only activate at certain point
    // TODO: Layers to differentiate between objects
    // TODO: Jank with using melee + throw at same time 
    // TODO: Update enemy prefabs to work with this trigger

    public GameObject aRock;

    public bool hasRock;
    public bool isThrowing;
    public bool isReleased;
    public bool isAttacking;
    public float timer = 0;
    public float cooldown = 0.25f;

    public GameObject rock;
    // public Collider2D rockSmashCollider;
    public PlayerMovement pm;
    public GameObject rockReleasePoint;

    public Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
        pm = GetComponent<PlayerMovement>();
    }

    void Update()
    {
        if (hasRock)
        {
            // There's gotta be a simpler way, but fuck it, mad at git, can't be bothered.

            // Input
            // RMB
            // Also throw will take precedence.
            // Removed single-frame check, sometimes it didn't register, so.
            if (Input.GetMouseButton(1))
            {
                isThrowing = true;
                //isAttacking = false;
            }
            // LMB
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
        if (isReleased && hasRock)
        {
            hasRock = false;
            isAttacking = false;
            isThrowing = false;
            GameObject thrown = GameObject.Instantiate(rock, rockReleasePoint.transform.position, new Quaternion(0,0,0,0));
        }
        animator.SetBool("IsAttacking", isAttacking);
        animator.SetBool("HasRock", hasRock);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Respawn")
        {
            Animator otherAnimator = other.GetComponent<Animator>();
            if (otherAnimator)
            {
                otherAnimator.Play("Enemy_Explode");
            }
        }
    }
}
