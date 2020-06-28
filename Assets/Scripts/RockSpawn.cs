using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockSpawn : MonoBehaviour
{
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

    PlayerViolence pv;

    bool hasStopped;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        upgradeManager = FindObjectOfType<UpgradeManager>();

        pv = FindObjectOfType<PlayerViolence>();
        movement = pv.pm.direction;
        
        size = upgradeManager.GetAttributeValue("size") + 1;
        range = upgradeManager.GetAttributeValue("range") + 3;
        speed = upgradeManager.GetAttributeValue("speed") + 1;

        if (movement.x != 0)
        {
            movement = new Vector2(movement.x * range * rangeMod, -1.96f);
            distance = rb.position + (movement);
        }
        else
        {
            distance = rb.position + (movement * (range * rangeMod));
            distance.y -= 1.96f;
        }

        startTime = Time.fixedTime;
        gameObject.transform.localScale *= (size * sizeMod);

        AudioManager.Instance.PlayPlayerSFX("Rock_Ranged");
        AudioManager.Instance.PlayMiscSFX("Rock_Ranged");
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (!hasStopped)
        {
            distCovered = (Time.fixedTime - startTime) * (speed * speedMod);
            journeyFraction = distCovered / Vector2.Distance(rb.position, distance);
            if (journeyFraction == Mathf.Infinity)
            {
                hasStopped = true;
                GetComponent<SpriteRenderer>().sortingOrder = -1;
            }

            rb.position = Vector2.Lerp(rb.position, distance, journeyFraction);
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        GameObject other = collider.gameObject;
        // Check for player collision (ie pick up)
        if (other.name == "Player" && hasStopped)
        {
            other.GetComponent<PlayerViolence>().hasRock = true;
            Destroy(this.gameObject);
        }
        else
        {
            AudioManager.Instance.PlayPlayerSFX("Rock_Hit");
            AudioManager.Instance.PlayMiscSFX("Rock_Hit");
        }
        // Check for animal collision
        if (other.tag == "Respawn")
        {
            AudioManager.Instance.PlayPlayerSFX("Blood_Flow");
            AudioManager.Instance.PlayMiscSFX("Blood_Flow");
            other.GetComponent<Animator>().Play("Enemy_Explode");
        }
        else
        {
            // ie obstacles
            hasStopped = true;
        }

    }
}
