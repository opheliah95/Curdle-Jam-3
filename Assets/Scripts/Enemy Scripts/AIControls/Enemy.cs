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
    public float speed = 2f, escapingRadius = 20f;

    [SerializeField]
    Vector3 startingPos;
    [SerializeField]
    Vector3 roamingPos;

    public Transform playerTransform;

    [SerializeField]
    bool flipLeft = false;

    protected void Start()
    {
        playerTransform = FindObjectOfType<PlayerMovement>().transform;
        startingPos = transform.position;
        roamingPos = randomMovement();
    }

    private void Update()
    {
        if (Escape())
            return;

        moveToPosition(roamingPos);
        // reached position, then restart again
        if (Vector3.Distance(transform.position, roamingPos) <= 0.1f)
        {
            // resetart whole movement and move to positon
            startingPos = transform.position;
            roamingPos = randomMovement();
            moveToPosition(roamingPos);
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
    protected Vector3 randomMovement()
    {
        return MyUtil.Util.GetSingleDir() + startingPos;

    }

    public void moveToPosition(Vector3 pos)
    {
        float step = speed * Time.deltaTime;
        // move sprite towards the target location
        transform.position = Vector2.MoveTowards(transform.position, pos, step);

        // flip sprite
        if ((pos.x < 0 && !flipLeft) || (pos.x > 0 && flipLeft))
        {
            flipEnemySide();
        }

    }

    // check escape
    public bool Escape()
    {
        Vector3 playerPos = playerTransform.position;
        
        // check if player in radius
        if (Vector3.Distance(transform.position, playerPos) < detectionRadius)
        {
            Debug.Log("escaping");
            Vector3 dirToPlayer = transform.position - playerPos;
            Vector3 newPos = dirToPlayer.normalized * escapingRadius + transform.position;
            moveToPosition(newPos);
            return true;
        
        }

        return false;
    }

    // check if enemy is stuck in wall
    public virtual void flipEnemySide()
    {
        flipLeft = !flipLeft;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;

    }
}
