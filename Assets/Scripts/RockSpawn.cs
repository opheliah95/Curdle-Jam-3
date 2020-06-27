using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockSpawn : MonoBehaviour
{
    // TODO: Direction, diag
    // TODO: Ignore player until stop
    // TODO: Release position based on size

    public UpgradeManager upgradeManager;
    public Rigidbody2D rb;

    public Vector2 movement;
    
    int size;
    public float sizeMod;
    public int range;
    public float rangeMod;
    public int speed;
    public float speedMod;
    
    [Header ("Test Variables")]
    public float startTime;
    public Vector2 distance;
    public float distCovered;
    public float journeyFraction;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        upgradeManager = FindObjectOfType<UpgradeManager>();

        size = upgradeManager.GetAttributeValue("size") + 1;
        range = upgradeManager.GetAttributeValue("range") + 1;
        speed = upgradeManager.GetAttributeValue("speed") + 1;

        startTime = Time.fixedTime;
        distance = rb.position + (movement * (range * rangeMod));
        gameObject.transform.localScale *= (size * sizeMod);
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        distCovered = (Time.fixedTime - startTime) * (speed * speedMod);
        journeyFraction = distCovered / Vector2.Distance(rb.position, distance);

        rb.position = Vector2.Lerp(rb.position, distance, journeyFraction);
    }

    // Call this after instantiating
    public void Thrown(Vector2 startPos, Vector2 dir)
    {
        rb.position = startPos;
        movement = dir;
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    private void OnTriggerEnter2D(Collider2D collider)
    {
        GameObject other = collider.gameObject;
        // Check for animal collision

        // Check for obstacle collision

        // Check for player collision (ie pick up)
        if (other.name == "Player")
        {
            other.GetComponent<PlayerViolence>().hasRock = true;
            Destroy(this.gameObject);
        }
    }
}
