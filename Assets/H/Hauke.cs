using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hauke
{
    public static void ScrapyardClick()
    {
        int random = Random.Range(0, 101);
        int[] dropchances = new int[2] { 65, 85 };

        Variables.resScraps = Variables.resScraps + (1 * Variables.clickMultiplier);

        if (random >= dropchances[0])
        {
            Variables.resPlastics = Variables.resPlastics + (1 * Variables.clickMultiplier);
        }
        if (random >= dropchances[1])
        {
            Variables.resElectronics = Variables.resElectronics + (1 * Variables.clickMultiplier);
        }
    }

    public static void ScrapYardCollector()
    {
        //---------------------ZeitRythmus-----------------------------
        if (Variables.timeInTicks >= Variables.tickCounter)
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
            Variables.tickCounter += 1;
        }
        //-------------------------------------------------------------
    }
    //-------------------------------------------------------------
    public static void ScrapYardCollectorMuliplierCalculation()
    {
        if (Variables.scrapYardCollector >= 1)
        {
            Variables.scrapYardCollectorMultiplier = Variables.startScrapYardCollectorMultiplier * Variables.scrapYardCollector;
        }
    }
    //-------------------------------------------------------------
}
