using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerViolence : MonoBehaviour
{
    // TODO: Pull stats from Rock - swing speed, aoe, throw area, throw speed
    // TODO: Fill in that skeleton
    // TODO: Animations and timers

    public bool isThrowing;
    public bool isSwinging;
    public float cooldown = 0.25f;
    
    void Update()
    {
        // Input
        // LMB
        // Single click because you can't spam-throw
        if (Input.GetMouseButtonDown(0))
        {
            RockThrow();
        }
        // RMB
        // Down for repeated swinging
        if (Input.GetMouseButton(1))
        {
            RockSmash();
        }
    }

    private void FixedUpdate()
    {
        // Using input
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
