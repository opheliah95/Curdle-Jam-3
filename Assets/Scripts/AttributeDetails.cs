using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttributeDetails : MonoBehaviour
{
    public string attName;
    public int baseValue;
    public int attValue = -1;
    public GameObject[] nodes;

    public Material redMat;

    void Start()
    {
        if(baseValue > 0)
        {
            for(int i = 0; i < baseValue; i++)
            {
                nodes[i].GetComponent<MeshRenderer>().material = redMat;
            }
        }
    }
}
