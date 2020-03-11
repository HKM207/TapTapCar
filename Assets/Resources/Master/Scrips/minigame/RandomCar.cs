using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RandomCar
{
    SortOfRes sort;
    ShowClickRes clickRes;
    public RandomCar()
    {

    }

    public RandomCar(int rndSort)
    {
        float rndResGetter;

        switch (rndSort)
        {
            case 1:
                this.sort = SortOfRes.scrap;
                clickRes = new ShowClickRes(Scrapyard.scrapyardPosition + new Vector3(0, 400, 0),this.sort);
                
                rndResGetter = Random.Range(50f, 75f) * Variables.playerLevel;
                clickRes.text.color = Color.red;
                clickRes.text.text = "+" + ((int)rndResGetter).ToString();
                Variables.resScraps = Variables.resScraps + rndResGetter;
                break;
            case 2:
                this.sort = SortOfRes.plastic;
                clickRes = new ShowClickRes(Scrapyard.scrapyardPosition + new Vector3(0, 400, 0),this.sort);
                
                rndResGetter = Random.Range(25f, 50f) * Variables.playerLevel;
                clickRes.text.color = Color.red;
                clickRes.text.text = "+" + ((int)rndResGetter).ToString();
                Variables.resPlastics = Variables.resPlastics + rndResGetter;
                break;
            case 3:
                this.sort = SortOfRes.electronic;
                clickRes = new ShowClickRes(Scrapyard.scrapyardPosition + new Vector3(0, 400, 0), this.sort);
                
                rndResGetter = Random.Range(15f, 30f) * Variables.playerLevel;
                clickRes.text.color = Color.red;
                clickRes.text.text = "+" + ((int)rndResGetter).ToString();
                Variables.resElectronics = Variables.resElectronics + rndResGetter;
                break;
            //case 4:
            //    this.sort = SortOfRes.Money;
            //    rndResGetter = (Random.Range(50f, 75f) * 100) * Variables.playerLevel;
            //    clickRes.text.color = Color.red;
            //    clickRes.text.text = rndResGetter.ToString();
            //    Variables.playerMoney = Variables.playerMoney + rndResGetter;
            //    break;
           default:
                break;
        }



    }

	
}
