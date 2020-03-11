using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[System.Serializable]
public class Car
{
    public string name;
    public int moneyValue;
    public int expValue;
    public int level;
    public int upgradeLevel;
    public int upgradeCosts;

    public int requiredScrap = 2;
    public int requiredPlastics = 4;
    public int requiredElectronics = 2;

   
    public Car()
    {
        //Debug.Log("works");
        //this.upgradeCosts = this.moneyValue * 2;
        SetValues();
    }
    public Car(int _level)
    {
        this.level = _level;
        SetValues();
    }

    public void SetValues()
    {
        
        this.upgradeCosts = this.upgradeCosts * this.moneyValue * 2;
        this.moneyValue = this.moneyValue * this.level;
        this.expValue = this.expValue * this.level;
        this.requiredScrap = this.requiredScrap * this.level;
        this.requiredPlastics = this.requiredPlastics * this.level;
        this.requiredElectronics = this.requiredElectronics * this.level;
        this.upgradeLevel = 1;

    }

}
