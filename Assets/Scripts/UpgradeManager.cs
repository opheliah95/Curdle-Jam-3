using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeManager : MonoBehaviour
{
    public int points;

    public AttributeDetails[] attDetails;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int GetAttributeValue(string att)
    {
        foreach(AttributeDetails attDetail in attDetails)
        {
            if(attDetail.attName == att)
            {
                return attDetail.attValue;
            }
        }

        return -1;
    }

    public void Increment(string att, Sprite s)
    {
        if (points > 0)
        {
            foreach (AttributeDetails attDetail in attDetails)
            {
                if (attDetail.attName == att)
                {
                    if (attDetail.attValue < 4)
                    {
                        attDetail.attValue++;
                        attDetail.nodes[attDetail.attValue].GetComponent<Image>().sprite = s;

                        points--;
                    }

                    break;
                }
            }
        }
    }

    public void Decrement(string att, Sprite s)
    {
        foreach (AttributeDetails attDetail in attDetails)
        {
            if (attDetail.attName == att)
            {
                if (attDetail.attValue > attDetail.baseValue - 1)
                {
                    attDetail.nodes[attDetail.attValue].GetComponent<Image>().sprite = s;
                    attDetail.attValue--;

                    points++;
                }

                break;
            }
        }
    }
}
