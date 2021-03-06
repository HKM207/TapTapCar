﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hauke
{
    public static void ScrapyardClick()
    {
        Variables.clicks++;
        StatsDisplay.clickTick = 0;
        Variables.totalClicks++;
        if (Variables.totalClicks % 10 == 0)
        {
            RandomCar randomGift = new RandomCar(Random.Range(1, 4));
        }
        int random = Random.Range(0, 101);
        int[] dropchances = new int[2] { 65, 85 };

        Variables.resScraps = Variables.resScraps + (1 * Variables.clickMultiplier);
        Scrapyard.DisplayScrapClick();

        if (random >= dropchances[0])
        {
            Variables.resPlastics = Variables.resPlastics + (1 * Variables.clickMultiplier);
            Scrapyard.DisplayElectronicClick();
        }
        if (random >= dropchances[1])
        {
            Variables.resElectronics = Variables.resElectronics + (1 * Variables.clickMultiplier);
            Scrapyard.DisplayPlasticsClick();
        }
    }
    public static void ScrapyardWorker()
    {
        if (Variables.scrapYardCollector >= 1)
        {
            if (Variables.workerTick == 0)
            {
                Variables.workerTick = Variables.tickCounter;
            }
            if (Variables.timeInTicks >= Variables.workerTick)
            {
                int random = Random.Range(0, 101);
                int[] dropchances = new int[2] { 55, 75 };

                Variables.resScraps = Variables.resScraps + (1 * Variables.scrapYardCollectorMultiplier);

                if (random >= dropchances[0])
                {
                    Variables.resPlastics = Variables.resPlastics + (1 * Variables.scrapYardCollectorMultiplier);
                }
                if (random >= dropchances[1])
                {
                    Variables.resElectronics = Variables.resElectronics + (1 * Variables.scrapYardCollectorMultiplier);
                }
                Variables.workerTick += 1;
            }
        }
    }
    public static void ScrapYardWorkerMultiplierCalculation()
    {
        if (Variables.scrapYardCollector >= 1)
        {
            Variables.scrapYardCollectorMultiplier = Variables.startScrapYardCollectorMultiplier * Variables.scrapYardCollector;
        }
    }

    public static void ResearchFacilityUpgradeCostCalculations()
    {
        if (Variables.isResearchFacilityActiv)
        {
            if (Variables.clickMultiplierUpgradeCosts <= Variables.clickMultiplierUpgradeStartCosts)
            {
                Variables.clickMultiplierUpgradeCosts = Variables.clickMultiplierUpgradeStartCosts;
            }
        }
    }
    public static void HardReset()
    {
        Variables.resScraps = 0;
        Variables.resElectronics = 0;
        Variables.resPlastics = 0;

       

        Variables.playerLevel = 1;
        Variables.playerMoney = 0;
        Variables.playerMoneyTotel = 0;
        Variables.playerGems = 0;
        Variables.totelResets = 0;
        Variables.playerExperience = 0;


        Variables.carValueMultiplier = 1;
        Variables.soldCars = 0;

        Variables.timeInSek = 0;
        Variables.tickCounter = 1;
        Variables.workerTick = 0;
        Variables.timeInTicks = 0;

        Variables.workerCost = 5000;
        Variables.scrapYardCollectorMultiplier = Variables.startScrapYardCollectorMultiplier;
        Variables.scrapYardCollector = 0;
        Variables.isResearchFacilityActiv = false;

        Variables.clickMultiplierUpgradeCosts = Variables.clickMultiplierUpgradeStartCosts;
        Variables.clickMultiplierUpgrades = 0;
        Variables.clickMultiplier = 1;
    }
    public static void ExpendingReset()
    {
        Variables.playerGems = Variables.playerGems + (Variables.playerMoneyTotel / 10000);

        Variables.resScraps = 0;
        Variables.resElectronics = 0;
        Variables.resPlastics = 0;

        Variables.playerLevel = 1;
        Variables.playerMoney = 0;
        Variables.playerMoneyTotel = 0;
        Variables.totelResets++;
        Variables.playerExperience = 0;

        Variables.carValueMultiplier = 1;;
        Variables.soldCars = 0;

        Variables.timeInSek = 0;
        Variables.tickCounter = 1;
        Variables.workerTick = 0;
        Variables.timeInTicks = 0;

        Variables.workerCost = 5000;
        Variables.scrapYardCollectorMultiplier = Variables.startScrapYardCollectorMultiplier;
        Variables.scrapYardCollector = 0;

        Variables.isResearchFacilityActiv = false;

        Variables.clickMultiplierUpgradeCosts = Variables.clickMultiplierUpgradeStartCosts;
        Variables.clickMultiplierUpgrades = 0;
        Variables.clickMultiplier = 1;

        Debug.Log("Gems: " + Variables.playerGems);
        Debug.Log("resets: " + Variables.totelResets);
    }
}
