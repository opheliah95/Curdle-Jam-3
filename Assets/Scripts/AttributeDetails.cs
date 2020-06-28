using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttributeDetails : MonoBehaviour
{
    public string attName;
    public int baseValue;
    public int attValue;
    public GameObject[] nodes;

    public Sprite filled;

    void Start()
    {
        if(baseValue > 0)
        {
            for(int i = 0; i < baseValue; i++)
            {
                nodes[i].GetComponent<Image>().sprite = filled;
            }
        }
    }
}
