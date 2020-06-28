using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : Enemy
{
    protected override void Update()
    {
        Escape();
        GetComponent<Animator>().SetBool("playerDetected", isEscaping);
    }
}
