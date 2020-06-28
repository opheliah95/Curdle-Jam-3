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
    protected Vector3 randomMovement()
    {
        return MyUtil.Util.GetRandomDir() + startingPos;

    }

    public void moveToPosition(Vector3 pos)
    {
        float step = speed * Time.deltaTime;
        // move sprite towards the target location
        transform.position = Vector2.MoveTowards(transform.position, pos, step);
    }

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


}
