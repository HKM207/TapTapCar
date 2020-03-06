using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FacilityShop : MonoBehaviour
{
    public static Button facilityButton;
    public Button[] buttons;

    public void Awake()
    {
        facilityButton = Resources.Load<Button>("Prefabs/facilityButton");
    }

    void Start()
    {
        Button facilityBtn;
        for (int i = 0; i < 4; i++)
        {
            facilityBtn = Instantiate(facilityButton);
            facilityBtn.gameObject.name = "Button_" + i.ToString() + "0";
            facilityBtn.gameObject.transform.SetParent(this.gameObject.transform);
            facilityBtn.gameObject.transform.position = new Vector3(270, 1530, 0) + new Vector3(0, -200 * i, 0);
            for (int k = 1; k < 4; k++)
            {
                facilityBtn = Instantiate(facilityButton);
                facilityBtn.gameObject.name = "Button_" + i.ToString() + k.ToString();
                facilityBtn.gameObject.transform.SetParent(this.gameObject.transform);
                facilityBtn.gameObject.transform.position = new Vector3(270, 1530, 0) + new Vector3(300 * k, -200 * i, 0);
            }
        }
        buttons = this.GetComponentsInChildren<Button>();
        buttons[0].onClick.AddListener(ClickMultiplier);
        buttons[1].onClick.AddListener(DebugTest1);
        buttons[2].onClick.AddListener(DebugTest2);
        buttons[3].onClick.AddListener(DebugTest3);
        buttons[4].onClick.AddListener(DebugTest4);
        buttons[5].onClick.AddListener(DebugTest5);
        buttons[6].onClick.AddListener(DebugTest6);
        buttons[7].onClick.AddListener(DebugTest7);
        buttons[8].onClick.AddListener(DebugTest8);
        buttons[9].onClick.AddListener(DebugTest9);
        buttons[10].onClick.AddListener(DebugTest10);
        buttons[11].onClick.AddListener(DebugTest11);
        buttons[12].onClick.AddListener(DebugTest12);
        buttons[13].onClick.AddListener(DebugTest13);
        buttons[14].onClick.AddListener(DebugTest14);
        buttons[15].onClick.AddListener(DebugTest15);
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