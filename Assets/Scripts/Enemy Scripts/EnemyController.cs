using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public enum EnemyState
    {
        idle,
        moving,
        attacking,
        fleeing,
        dead
    }

    EnemyData nmeData;

    // Start is called before the first frame update
    void Start()
    {
        nmeData = GetComponent<EnemyData>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool IsHit()
    {
        // Call this when the enemy is hit
        // Call nmeData.experience to get tasty blood-sploosh gains and add it to player

        return false;
    }
}
