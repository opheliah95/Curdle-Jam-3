using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyUtil;

public class Enemy : MonoBehaviour
{
    [Tooltip("how far enemy can see")]
    public float detectionRadius = 3f;
    [Tooltip("how fast they can run")]
    public float speed = 2f, escapingSpeed = 10f, escapingRadius = 20f;

    [SerializeField]
    protected Vector3 startingPos;
    [SerializeField]
    protected Vector3 roamingPos;

    public Transform playerTransform;

    [SerializeField]
    public bool flipLeft = false;
    [SerializeField]
    protected bool isEscaping = false;

    [SerializeField]
    protected float distance;
    protected virtual void Start()
    {
        playerTransform = FindObjectOfType<PlayerMovement>().transform;
        startingPos = transform.position;
        roamingPos = randomMovement();
    }

    protected virtual void Update()
    {
        distance = Util.GetRoundedDistance(transform.position, playerTransform.position);
        Escape();
        GetComponent<Animator>().SetBool("playerDetected", isEscaping);
        if (!isEscaping)
        {
            moveToPosition(roamingPos, speed);
            // reached position, then restart again
            if (Vector3.Distance(transform.position, roamingPos) <= 0.1f)
            {
                // resetart whole movement and move to positon
                startingPos = transform.position;
                roamingPos = randomMovement();
                moveToPosition(roamingPos, speed);
            }

        }
  
    }

    public void Idle()
    {
      
    }

    public void Flee()
    {

    }

    // comment this function out in final stage
    public void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }

    // enemy will move in random directions
    // fine tune so that enemy only move in one direction
    protected virtual Vector3 randomMovement()
    {
        return Util.GetRandomDir() + startingPos;

    }

    public virtual void moveToPosition(Vector3 pos, float movingSpeed)
    {
        float step = movingSpeed * Time.deltaTime;
        // move sprite towards the target location
        transform.position = Vector2.MoveTowards(transform.position, pos, step);

        // flip sprite ---side only
        if ((pos.x < 0 && !flipLeft) || (pos.x > 0 && flipLeft))
        {
            flipEnemySide();
        }

        // flip sprites ---up/down
    }

    // check escape
    public virtual void Escape()
    {
        Vector3 playerPos = playerTransform.position;

        // check if player in radius
        if (Util.GetRoundedDistance(transform.position, playerPos) <= detectionRadius && !isEscaping)
        {
            isEscaping = true;
        }
        else
        {
            isEscaping = false;
            return;
        }

    }

    // check if enemy is stuck in wall
    public virtual void flipEnemySide()
    {
        flipLeft = !flipLeft;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;

    }
    /*
    protected virtual void EscapeImplementation()
    {
        Debug.Log("escaping");
        Vector3 dirToPlayer = transform.position - playerPos;
        Vector3 newPos = dirToPlayer * escapingRadius + transform.position;
        Debug.Log("New pos is: " + newPos);
        moveToPosition(newPos, escapingSpeed);
        isEscaping = true;

    }
    */

    public void assignFacingDirection()
    {
        if (flipLeft)
            transform.localScale = new Vector2(-1, 1);
        else
            transform.localScale = new Vector2(1, 1);

        Debug.Log("sorted");
    }

    
}
