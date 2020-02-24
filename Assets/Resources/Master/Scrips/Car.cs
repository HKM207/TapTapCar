using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Car
{
    public string name;

    public int moneyValue = 500;
    public int expValue = 500;
    public int requiredLevel;

    public int requiredEngines = 2;
    public int requiredTires = 4;
    public int requiredFrames = 2;

    public Button button;


    public Car(Button _button, int _requiredLevel)
    {
        this.button = _button;
        this.requiredLevel = _requiredLevel;

        //Balancing
        this.moneyValue = this.moneyValue * this.requiredLevel;
        this.expValue = this.expValue * this.requiredLevel;
        this.requiredEngines = this.requiredEngines * this.requiredLevel;
        this.requiredTires = this.requiredTires * this.requiredLevel;
        this.requiredFrames = this.requiredFrames * this.requiredLevel;
    }




}
