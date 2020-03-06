using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

/// <summary>
/// This Script is attached to the CarUIElement
/// Displays Cars Values and gets clicks. 
/// Is beeing entered into List be IngameUI.
/// </summary>
public class CarElement : MonoBehaviour
{
    public Text engineCosts;
    public Text tireCosts;
    public Text frameCosts;
    public Text requiredLevel;

    public Text upgradeCosts;
    public Text xpReward;

    public Button btnSellCar; // Assigned by Hand in the Inspector
    public Button btnUpgradeCar;
    UnityAction sellCarMethodCall; //Action is the delegate without returntype
    UnityAction upgradeCarMethodCall;
 
    Car car;

    void Start ()
    {
        sellCarMethodCall += SellCar;
        btnSellCar.onClick.AddListener(sellCarMethodCall);
	}

    public void SetCarInfos(Car car)
    {
        this.car = car;
        engineCosts.text = car.requiredEngines.ToString();
        tireCosts.text = car.requiredTires.ToString();
        frameCosts.text = car.requiredFrames.ToString();
        requiredLevel.text = car.level.ToString();
        upgradeCosts.text =  car.moneyValue.ToString();
        xpReward.text = car.expValue.ToString();
        Debug.Log("Car Info Given To UI ");
    }

public void SellCar()
    {
        if (Variables.partEngines >= car.requiredEngines &&
            Variables.partFrames >= car.requiredFrames &&
            Variables.partTires >= car.requiredTires &&
            Variables.playerLevel >= car.level)
        {
            Debug.Log("Selling Car ");
            Variables.soldCars++;
            Variables.partEngines = Variables.partEngines - car.requiredEngines;
            Variables.partFrames = Variables.partFrames - car.requiredFrames;
            Variables.partTires = Variables.partTires - car.requiredTires;

            Variables.playerExperience = Variables.playerExperience + car.expValue;
            Variables.playerMoney = Variables.playerMoney + (car.moneyValue * Variables.carValueMultiplier);
            Variables.playerMoneyTotel = Variables.playerMoneyTotel + (car.moneyValue * Variables.carValueMultiplier);
        }
        else
        {
            Debug.Log("Requirements not met, selling it anyway ");
            Variables.soldCars++;
            Variables.partEngines = Variables.partEngines - car.requiredEngines;
            Variables.partFrames = Variables.partFrames - car.requiredFrames;
            Variables.partTires = Variables.partTires - car.requiredTires;

            Variables.playerExperience = Variables.playerExperience + car.expValue;
            Variables.playerMoney = Variables.playerMoney + (car.moneyValue * Variables.carValueMultiplier);
            Variables.playerMoneyTotel = Variables.playerMoneyTotel + (car.moneyValue * Variables.carValueMultiplier);
        }
    }
}
