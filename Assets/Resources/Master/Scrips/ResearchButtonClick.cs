using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResearchButtonClick : MonoBehaviour
{
    public static List<ButtonClass> buttons = new List<ButtonClass>();
    public TextAsset infoFile;
    public static bool buttonActive = false;
    public static GameObject infoText;

    public static Text UpgradeName;
    public static Text Description;
    public static Button buy;
    public static Button cancle;

    private void Start()
    {

        infoText = Instantiate(Resources.Load<GameObject>("Prefabs/InfoPrefab"));
        SetGameObjects();
        cancle.onClick.AddListener(DisableInfo);
        buy.onClick.AddListener(Buy);
        infoText.SetActive(false);

        //Variables.researchButtons = JsonHelper.getJsonArray<ResearchButton>(infoFile.text);
        //if (Variables.researchButtons != null)
        //{
        //    Debug.Log("info succesfully read");
        //}
        //else
        //{
        //    Debug.Log("info not read");
        //}

    }

    void DisableInfo()
    {
        infoText.SetActive(false);
    }

    void Buy()
    {
        //money etc
        Debug.Log("bought upgrade");
        infoText.SetActive(false);
    }

    bool SetGameObjects()
    {
        GameObject go;
        go = infoText.transform.Find("UpgradeBackground").gameObject;
        Transform[] transformArray = go.GetComponentsInChildren<Transform>();
        if (transformArray == null)
        {
            Debug.Log("failed finding children of dialog text");
            return false;
        }
        else
        {
            foreach (Transform item in transformArray)
            {
                if (item != null && item.gameObject != null)
                {
                    if (item.gameObject.name == "UpgradeName")
                    {
                        UpgradeName = item.gameObject.GetComponent<Text>();
                    }
                    else if (item.gameObject.name == "UpgradeDescription")
                    {
                        Description = item.gameObject.GetComponent<Text>();
                    }
                    else if (item.gameObject.name == "Buy")
                    {
                        buy = item.gameObject.GetComponent<Button>();
                    }
                    else if (item.gameObject.name == "Cancle")
                    {
                        cancle = item.gameObject.GetComponent<Button>();
                    }
                }
            }
            return true;
        }
    }
}

[System.Serializable]
public class FacilityButtonClass
{
    public int cost;
    public string upgradeName;
    public string description;

    public FacilityButtonClass()
    {

    }
}
