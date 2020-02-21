using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Car
{
    public string name;

    public int moneyValue = 500;
    public int expValue = 500;

    public int requiredEngines = 1;
    public int requiredTires = 0;
    public int requiredFrames = 0;

    public Button button;


    public Car(Button _button)
    {
        this.button = _button;

    }




}
