using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Factory : MonoBehaviour
{
    private Button button;

    public Button EngineProduction;
    public Button FrameProduction;
    public Button TireProduction;

    void Start()
    {
        button = this.gameObject.GetComponent<Button>();
        button.onClick.AddListener(IngameUi.EnableFactoryUI);

        //EngineProduction.onClick.AddListener(delegate { UpgradeFactory(0); });
        //FrameProduction.onClick.AddListener(delegate { UpgradeFactory(1); });
        //TireProduction.onClick.AddListener(delegate { UpgradeFactory(2); });
    }
    public void UpgradeFactory(int i)
    {
    //    if (i == 0)
    //    {
    //        Variables.isFactoryActiv = true;
    //        Hauke.FactoryCostsCalculation();
    //        if (Variables.playerMoney >= Variables.factoryCost)
    //        {
    //            Variables.playerMoney = Variables.playerMoney - Variables.factoryCost;
    //            Variables.engineProductionRatio = Variables.engineProductionRatio + 0.1f;
    //            Variables.factoryUpgrades++;
    //        }
    //        else
    //        {
    //            IngameUi.DisplayDialogBox("kein geld für fabrik", "Error");
    //        }
    //    }
    //    else if (i == 1)
    //    {
    //        Variables.isFactoryActiv = true;
    //        Hauke.FactoryCostsCalculation();
    //        if (Variables.playerMoney >= Variables.factoryCost)
    //        {
    //            Variables.playerMoney = Variables.playerMoney - Variables.factoryCost;
    //            Variables.frameProductionRatio = Variables.frameProductionRatio + 0.1f;
    //            Variables.factoryUpgrades++;
    //        }
    //        else
    //        {
    //            Debug.Log("kein geld für fabrik");
    //        }
    //    }
    //    else if (i == 2)
    //    {
    //        Variables.isFactoryActiv = true;
    //        Hauke.FactoryCostsCalculation();
    //        if (Variables.playerMoney >= Variables.factoryCost)
    //        {
    //            Variables.playerMoney = Variables.playerMoney - Variables.factoryCost;
    //            Variables.tireProductionRatio = Variables.tireProductionRatio + 0.1f;
    //            Variables.factoryUpgrades++;
    //        }
    //        else
    //        {
    //            Debug.Log("kein geld für fabrik");
    //        }
    //    }
    //    else
    //    {
    //        Debug.Log("error 2 many buttonss");
    //    }
    }
}
