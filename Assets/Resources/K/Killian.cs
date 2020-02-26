using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Killian
{
    public static void LevelUpSystem(int levelUpMultiplier)
    {
       
        if (Variables.playerExperience >= Variables.expNeededForLvlUp && Variables.playerLevel == 1)
        {
            Variables.playerLevel++;
            Debug.Log("LEVEL UP, now level:" + Variables.playerLevel + "   EXP needed: " + NeededExp(levelUpMultiplier));
        }

        if (Variables.playerExperience >= NeededExp(levelUpMultiplier))
        {
            Variables.playerLevel++;
            Debug.Log("LEVEL UP, now level:" + Variables.playerLevel + "   EXP needed: " + NeededExp(levelUpMultiplier));
        }

    }

    public static float NeededExp(int lvlUpMultiplier)
    {

       float expNeed = Variables.expNeededForLvlUp * (Variables.playerLevel * Mathf.Pow(2,lvlUpMultiplier));

        return expNeed;
    }
}
