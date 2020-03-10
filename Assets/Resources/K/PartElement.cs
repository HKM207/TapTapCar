//using System;
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.Events;
//using UnityEngine.UI;

///// <summary>
///// This Script is attached to the CarUIElement
///// Displays Cars Values and gets clicks. 
///// Is beeing entered into List be IngameUI.
///// </summary>
//public class PartElement : MonoBehaviour
//{
//    public Text scrapCosts;
//    public Text plasticCosts;
//    public Text elecCosts;

//    public Text requiredLevel;

//    public Text upgradeCosts;
//    public Text xpReward;

//    public Button btnProducePart; // Assigned by Hand in the Inspector
//    public Button btnUpgradePart;
//    UnityAction producePartMethodCall; //Action is the delegate without returntype
//    UnityAction upgradeCarMethodCall;

//    Part part;

//    void Start()
//    {
//        producePartMethodCall += ProducePart;
//        btnProducePart.onClick.AddListener(producePartMethodCall);
//    }

//    public void SetPartInfos(Part part)
//    {
//        this.part = part;
//        scrapCosts.text = part.requiredScrap.ToString();
//        plasticCosts.text = part.requiredPlastics.ToString();
//        elecCosts.text = part.requiredElectronics.ToString();
//        requiredLevel.text = part.level.ToString();

//        //upgradeCosts.text = part.moneyValue.ToString();
//        //xpReward.text = part.expValue.ToString();
//        Debug.Log("Part Info Given To UI ");
//    }

//    public void ProducePart()
//    {
//        if (Variables.resScraps >= part.requiredScrap &&
//            Variables.resPlastics >= part.requiredPlastics &&
//            Variables.resElectronics >= part.requiredElectronics &&
//            Variables.playerLevel >= part.level)
//        {
//            Debug.Log("Producing Part ");
            
//            Variables.resScraps = Variables.resScraps - part.requiredScrap;
//            Variables.resPlastics = Variables.resPlastics - part.requiredPlastics;
//            Variables.resElectronics = Variables.resElectronics - part.requiredElectronics;

//            //Variables.playerExperience = Variables.playerExperience + part.expValue;
//            //Variables.playerMoney = Variables.playerMoney + (part.moneyValue * Variables.carValueMultiplier);
//            //Variables.playerMoneyTotel = Variables.playerMoneyTotel + (part.moneyValue * Variables.carValueMultiplier);
//        }
//        else
//        {
//            Debug.Log("Requirements not met, producing it anyway ");
//            Variables.resScraps = Variables.resScraps - part.requiredScrap;
//            Variables.resPlastics = Variables.resPlastics - part.requiredPlastics;
//            Variables.resElectronics = Variables.resElectronics - part.requiredElectronics;

//            //Variables.playerExperience = Variables.playerExperience + part.expValue;
//            //Variables.playerMoney = Variables.playerMoney + (part.moneyValue * Variables.carValueMultiplier);
//            //Variables.playerMoneyTotel = Variables.playerMoneyTotel + (part.moneyValue * Variables.carValueMultiplier);
//        }
//    }
//}