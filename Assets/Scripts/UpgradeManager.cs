using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeManager : MonoBehaviour
{
    private static UpgradeManager _instance;

    public static UpgradeManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<UpgradeManager>();
                if (_instance == null)
                {
                    GameObject obj = new GameObject();
                    obj.name = typeof(UpgradeManager).Name;
                    _instance = obj.AddComponent<UpgradeManager>();
                    DontDestroyOnLoad(obj);
                }
            }
            return _instance;
        }
    }

    public int points = 0;
    public int experience = 0;
    Text pointDisplay;

    public AttributeDetails[] attDetails;

    // Start is called before the first frame update
    void Start()
    {
        Object.DontDestroyOnLoad(gameObject);

        GetComponent<Canvas>().worldCamera = Camera.main;
        pointDisplay = transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<Text>();
        UpdatePointDisplay();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            GameObject childObject = transform.GetChild(0).gameObject;

            childObject.SetActive(childObject.activeSelf ? false : true);
        }
    }

    public void GainExperience(int exp)
    {
        experience += exp;
        if (experience == 3)
        {
            AudioManager.Instance.PlayUISFX("Blood_meter_filled_level_up");
            points++;
            UpdatePointDisplay();
            experience = 0;
        }
    }

    void UpdatePointDisplay()
    {
        pointDisplay.text = points.ToString();
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
                        UpdatePointDisplay();
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
                    UpdatePointDisplay();
                }

                break;
            }
        }
    }
}
