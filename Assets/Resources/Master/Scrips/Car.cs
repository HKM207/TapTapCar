using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Car
{
    public string name;

    public int moneyValue;
    public int expValue;

    public int requiredEngines = 1;
    public int requiredTires = 1;
    public int requiredFrames = 1;

    public Button button;


    public Car(Button _button)
    {
        this.button = _button;

    }




}
