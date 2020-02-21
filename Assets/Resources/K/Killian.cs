using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Killian
{
    public static void LevelUpSystem()
    {//need changing for consistent leveling

        for (int i = 1; i <= 10; i++)
        {
            if (Variables.playerExperience >= 1000 * i * (1.5f))
            {
                Variables.playerLevel = i;
            }
        }

    }



}
