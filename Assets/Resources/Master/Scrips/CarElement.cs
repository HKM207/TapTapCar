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
    public Text scrapCosts;
    public Text plasticCosts;
    public Text electronicsCosts;
    public Text requiredLevel;

    public Text upgradeCosts;
    public Text xpReward;

    public Button btnSellCar; // Assigned by Hand in the Inspector
    public Button btnUpgradeCar;
    UnityAction sellCarMethodCall; //Action is the delegate without returntype
    UnityAction upgradeCarMethodCall;

    Car car;

    void Start()
    {
        sellCarMethodCall += SellCar;
        upgradeCarMethodCall += UpgradeCar;
        btnUpgradeCar.onClick.AddListener(upgradeCarMethodCall);
        btnSellCar.onClick.AddListener(sellCarMethodCall);
    }

    public void SetCarInfos(Car car)
    {
        this.car = car;
        Sprite sprite = Resources.Load<Sprite>(car.name);
        btnSellCar.GetComponent<Image>().sprite = sprite;
        scrapCosts.text = car.requiredScrap.ToString();
        plasticCosts.text = car.requiredPlastics.ToString();
        electronicsCosts.text = car.requiredElectronics.ToString();
        requiredLevel.text = car.level.ToString();
        upgradeCosts.text = (car.upgradeCosts * car.moneyValue*2).ToString();
        xpReward.text = car.expValue.ToString();
        Debug.Log("Car Info Given To UI ");
    }

    public void SellCar()
    {
        if (Variables.resScraps >= car.requiredScrap &&
            Variables.resElectronics >= car.requiredElectronics &&
            Variables.resPlastics >= car.requiredPlastics &&
            Variables.playerLevel >= car.level)
        {
            Debug.Log("Selling Car ");
            Variables.soldCars++;
            Variables.resScraps = Variables.resScraps - car.requiredScrap;
            Variables.resElectronics = Variables.resElectronics - car.requiredElectronics;
            Variables.resPlastics = Variables.resPlastics - car.requiredPlastics;

            Variables.playerExperience = Variables.playerExperience + car.expValue;
            Variables.playerMoney = Variables.playerMoney + (car.moneyValue * Variables.carValueMultiplier * car.upgradeLevel);
            Variables.playerMoneyTotel = Variables.playerMoneyTotel + (car.moneyValue * Variables.carValueMultiplier * car.upgradeLevel);
        }
        else
        {
            Debug.Log("Requirements not met, selling it anyway ");
            Variables.soldCars++;
            Variables.resScraps = Variables.resScraps - car.requiredScrap;
            Variables.resElectronics = Variables.resElectronics - car.requiredElectronics;
            Variables.resPlastics = Variables.resPlastics - car.requiredPlastics;

            Variables.playerExperience = Variables.playerExperience + car.expValue;
            Variables.playerMoney = Variables.playerMoney + (car.moneyValue * Variables.carValueMultiplier);
            Variables.playerMoneyTotel = Variables.playerMoneyTotel + (car.moneyValue * Variables.carValueMultiplier);
        }
    }

    public void UpgradeCar()
    {
        if (Variables.playerMoney >= car.upgradeCosts )
        {
            Variables.playerMoney = Variables.playerMoney - (car.upgradeCosts * car.moneyValue);
            Debug.Log("UpgradedCar");
            car.upgradeLevel++;
        }

    }
}
