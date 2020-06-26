using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockSpawn : MonoBehaviour
{
    UpgradeManager upgradeManager;

    int size;
    int range;
    int speed;

    // Start is called before the first frame update
    void Start()
    {
        upgradeManager = FindObjectOfType<UpgradeManager>();

        size = upgradeManager.GetAttributeValue("size");
        range = upgradeManager.GetAttributeValue("range");
        speed = upgradeManager.GetAttributeValue("speed");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Call this after instantiating
    public void Thrown(Vector2 dir)
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check for animal collision

        // Check for obstacle collision
    }
}
