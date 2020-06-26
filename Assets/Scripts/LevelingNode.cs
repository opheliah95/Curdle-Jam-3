using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelingNode : MonoBehaviour
{
    public string attribute;
    public bool increments;
    public UpgradeManager upgradeManager;

    // Start is called before the first frame update
    void Start()
    {
        upgradeManager = FindObjectOfType<UpgradeManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseUp()
    {
        if (increments)
            upgradeManager.Increment(attribute);
        else
            upgradeManager.Decrement(attribute);
    }
}
