using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public enum SortOfPart
{
    Frame,
    Tire,
    Engine
}
public class Part
{
    //**// parts müssen hergestellt werden, bringen erfahrung, als klasse dargestellt, da sich durch verändern
    //**// des lvls die needs verändern
    //**// Scriptable objects? upgraden der teile für mehr geld? Enum um zu bestimmen welche art von Teil?
    //**// Klasse Car Part-Variablen geben? durch klicken auf garage, öffnet sich Fenster mit verfügbaren autos,
    //**// bei klick werden sie bei ausreichend vorhandenen teilen hergestellt
    //**// Auto zeigen ihren ihren "Fenstern" requirements an, grafische Darstellung des parts und anzahl



    //**// UPDATE: Car sollten scriptable objects sein, können dadurch in einer großen datenbank gespeichert werden
    //**// ausgelesen werden mit ihren dazugehörigen werten (requirments)
    //**// dadurch können viele verschiedene auto kombinationen erstellt werden, mit unterschiedlichen needs



    public int requiredScrap = 0;
    public int requiredPlastics = 0;
    public int requiredElectronics = 0;

    public SortOfPart sort;

    public int level;

    public Button button;


    //---------------KILIAN NEU--------------------------------------------------------------------------------//
    public Part(SortOfPart _sort,
                Button _button)
    {
    //---------------KILIAN NEU--------------------------------------------------------------------------------//
        this.button = _button;
        this.sort = _sort;


        if (this.sort == SortOfPart.Engine)
        {
            this.requiredScrap = 7;
            this.requiredPlastics = 3;
            this.requiredElectronics = 5;

            this.level = Variables.engineLevel;
            if (this.level >= 2)
            {
                this.requiredScrap = this.requiredScrap + (2 * this.level);
                this.requiredPlastics = this.requiredPlastics + (2 * this.level);
                this.requiredElectronics = this.requiredElectronics + (2 * this.level);
                Variables.carValueMultiplier = Variables.carValueMultiplier + (0.25f * this.level);

            }
        }


        if (this.sort == SortOfPart.Frame)
        {
            this.requiredScrap = 10;
            this.requiredPlastics = 3;
            this.requiredElectronics = 2;

            this.level = Variables.frameLevel;
            if (this.level >= 2)
            {
                this.requiredScrap = this.requiredScrap + (2 * this.level);
                this.requiredPlastics = this.requiredPlastics + (2 * this.level);
                this.requiredElectronics = this.requiredElectronics + (2 * this.level);
                Variables.carValueMultiplier = Variables.carValueMultiplier + (0.25f * this.level);
            }
        }


        if (this.sort == SortOfPart.Tire)
        {
            this.requiredScrap = 3;
            this.requiredPlastics = 10;
            this.requiredElectronics = 2;

            this.level = Variables.tireLevel;
            if (this.level >= 2)
            {
                this.requiredScrap = this.requiredScrap + (2 * this.level);
                this.requiredPlastics = this.requiredPlastics + (2 * this.level);
                this.requiredElectronics = this.requiredElectronics + (2 * this.level);
                Variables.carValueMultiplier = Variables.carValueMultiplier + (0.25f * this.level);
            }
        }






    }





}
