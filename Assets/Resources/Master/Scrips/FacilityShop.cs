using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class FacilityShop : MonoBehaviour
{
    public static Button facilityButton;
    public static Button[] buttons;
    static GameObject parent;

    public void Awake()
    {
        facilityButton = Resources.Load<Button>("Prefabs/facilityButton");
        parent = this.gameObject;
    }

    void Start()
    {
        Button facilityBtn;
        for (int i = 0; i < 4; i++)
        {
            facilityBtn = Instantiate(facilityButton);
            facilityBtn.gameObject.name = "Button_" + i.ToString() + "0";
            facilityBtn = ResetValues(facilityBtn);
            //facilityBtn.gameObject.transform.SetParent(this.gameObject.transform);
            //facilityBtn.gameObject.transform.position = new Vector3(270, 1530, 0) + new Vector3(0, -200 * i, 0);
            for (int k = 1; k < 4; k++)
            {
                facilityBtn = Instantiate(facilityButton);
                facilityBtn.gameObject.name = "Button_" + i.ToString() + k.ToString();
                facilityBtn = ResetValues(facilityBtn);
                //facilityBtn.gameObject.transform.SetParent(this.gameObject.transform);
                //facilityBtn.gameObject.transform.position = new Vector3(270, 1530, 0) + new Vector3(300 * k, -200 * i, 0);
            }
        }
        buttons = this.GetComponentsInChildren<Button>();
        int count = 0;
        foreach (var item in buttons)
        {
            item.onClick.AddListener(delegate { FacilityButtonMethod(item); });
            count++;
        }
    }

    public static Button ResetValues(Button button)
    {
        RectTransform rect = button.GetComponent<RectTransform>();
        rect.gameObject.transform.SetParent(parent.gameObject.transform);
        rect.offsetMin = rect.offsetMax = Vector2.zero;
        rect.localScale = new Vector3(1, 1, 1);
        return button;
    }

    void FacilityButtonMethod(Button  button)
    {
        int buttonIndex = button.transform.GetSiblingIndex();
        Debug.Log("Clicked Button was " + button.gameObject.name);
        Debug.Log("Buttons index is " + buttonIndex);
        switch (buttonIndex)
        {
            case 1:
                ClickMultiplier();
                break;
            case 2:
                DebugTest1();
                break;
            default:
                break;
        }
    }

    private void ClickMultiplier()
    {

        if (Variables.isResearchFacilityActiv)
        {
            if (Variables.playerMoney >= Variables.clickMultiplierUpgradeCosts)
            {
                Variables.playerMoney = Variables.playerMoney - Variables.clickMultiplierUpgradeCosts;
                Variables.clickMultiplierUpgrades++;
                Variables.clickMultiplier = Variables.clickMultiplier * Variables.clickMultiplierUpgrades;

                Variables.clickMultiplierUpgradeCosts = Variables.clickMultiplierUpgradeCosts * (Variables.clickMultiplierUpgrades * 4);
                Debug.Log("clickMultiplier: " + Variables.clickMultiplier);
                Debug.Log("Kosten: " + Variables.clickMultiplierUpgradeCosts);
                Debug.Log("anzahl Upgrades: " + Variables.clickMultiplierUpgrades);
            }
        }
    }

    private void DebugTest1()
    {
        Debug.Log("Button_1");
    }
    private void DebugTest2()
    {
        Debug.Log("Button_2");
    }
    private void DebugTest3()
    {
        Debug.Log("Button_3");
    }
    private void DebugTest4()
    {
        Debug.Log("Button_4");
    }
    private void DebugTest5()
    {
        Debug.Log("Button_5");
    }
    private void DebugTest6()
    {
        Debug.Log("Button_6");
    }
    private void DebugTest7()
    {
        Debug.Log("Button_7");
    }
    private void DebugTest8()
    {
        Debug.Log("Button_8");
    }
    private void DebugTest9()
    {
        Debug.Log("Button_9");
    }
    private void DebugTest10()
    {
        Debug.Log("Button_10");
    }
    private void DebugTest11()
    {
        Debug.Log("Button_11");
    }
    private void DebugTest12()
    {
        Debug.Log("Button_12");
    }
    private void DebugTest13()
    {
        Debug.Log("Button_13");
    }
    private void DebugTest14()
    {
        Debug.Log("Button_14");
    }
    private void DebugTest15()
    {
        Debug.Log("Button_15");
    }
}