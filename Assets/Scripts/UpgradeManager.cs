using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    public int points;

    public AttributeDetails[] attDetails;

    public Material defaultMat;
    public Material redMat;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Increment(string att)
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
                        attDetail.nodes[attDetail.attValue].GetComponent<MeshRenderer>().material = redMat;

                        points--;
                    }

                    break;
                }
            }
        }
    }

    public void Decrement(string att)
    {
        foreach (AttributeDetails attDetail in attDetails)
        {
            if (attDetail.attName == att)
            {
                if (attDetail.attValue > attDetail.baseValue - 1)
                {
                    attDetail.nodes[attDetail.attValue].GetComponent<MeshRenderer>().material = defaultMat;
                    attDetail.attValue--;

                    points++;
                }

                break;
            }
        }
    }
}
