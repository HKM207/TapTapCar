//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;


//public enum SortOfPart
//{
//    Frame,
//    Tire,
//    Engine
//}
//public class Part
//{
//    public int requiredScrap = 0;
//    public int requiredPlastics = 0;
//    public int requiredElectronics = 0;

//    public SortOfPart sort;

//    public int level;

//    public Button button;

//    public Part(SortOfPart _sort)            
//    {
//        this.sort = _sort;
//        if (this.sort == SortOfPart.Engine)
//        {
//            this.requiredScrap = 7;
//            this.requiredPlastics = 3;
//            this.requiredElectronics = 5;

//            this.level = Variables.engineLevel;
//            if (this.level >= 2)
//            {
//                this.requiredScrap = this.requiredScrap + (2 * this.level);
//                this.requiredPlastics = this.requiredPlastics + (2 * this.level);
//                this.requiredElectronics = this.requiredElectronics + (2 * this.level);
//                Variables.carValueMultiplier = Variables.carValueMultiplier + (0.25f * this.level);
//            }
//        }

//        if (this.sort == SortOfPart.Frame)
//        {
//            this.requiredScrap = 10;
//            this.requiredPlastics = 3;
//            this.requiredElectronics = 2;

//            this.level = Variables.frameLevel;
//            if (this.level >= 2)
//            {
//                this.requiredScrap = this.requiredScrap + (2 * this.level);
//                this.requiredPlastics = this.requiredPlastics + (2 * this.level);
//                this.requiredElectronics = this.requiredElectronics + (2 * this.level);
//                Variables.carValueMultiplier = Variables.carValueMultiplier + (0.25f * this.level);
//            }
//        }
        
//        if (this.sort == SortOfPart.Tire)
//        {
//            this.requiredScrap = 3;
//            this.requiredPlastics = 10;
//            this.requiredElectronics = 2;

//            this.level = Variables.tireLevel;
//            if (this.level >= 2)
//            {
//                this.requiredScrap = this.requiredScrap + (2 * this.level);
//                this.requiredPlastics = this.requiredPlastics + (2 * this.level);
//                this.requiredElectronics = this.requiredElectronics + (2 * this.level);
//                Variables.carValueMultiplier = Variables.carValueMultiplier + (0.25f * this.level);
//            }
//        }
//    }
//}
