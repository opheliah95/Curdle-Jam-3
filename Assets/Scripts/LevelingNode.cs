using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelingNode : MonoBehaviour
{
    public UpgradeManager upgradeManager;

    public string attribute;
    public bool increments;
    public Sprite empty;
    public Sprite filled;

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
            upgradeManager.Increment(attribute, filled);
        else
            upgradeManager.Decrement(attribute, empty);
    }
}
