using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum SortOfRes
{
    scrap,
    electronic,
    plastic

}
public class ShowClickRes
{
    public int counter = 0;
    public Image image;
    public Text text;
    public SortOfRes sortOfRes;

    public ShowClickRes()
    {

    }
    public ShowClickRes(SortOfRes _sortOfRes)
    {
        this.sortOfRes = _sortOfRes;

        ++counter;
        

        
        this.image = GameObject.Instantiate(Variables.clickImage);

        //this.text = GameObject.Instantiate(Variables.clickText);
        this.image.gameObject.SetActive(false);

        
        if (this.sortOfRes == SortOfRes.scrap)
        {
            Sprite sprite = Resources.Load<Sprite>("scrap");
            this.image.GetComponent<Image>().sprite = sprite;

            this.image.gameObject.SetActive(false);

        }
        else if (this.sortOfRes == SortOfRes.electronic)
        {
            Sprite sprite = Resources.Load<Sprite>("electronics");
            this.image.GetComponent<Image>().sprite = sprite;
            this.image.gameObject.SetActive(false);
        }
        else if (this.sortOfRes == SortOfRes.plastic)
        {
            Sprite sprite = Resources.Load<Sprite>("plastics");
            this.image.GetComponent<Image>().sprite = sprite;
            this.image.gameObject.SetActive(false);
        }
        else
        {
            Debug.Log("no SortOfRes Defined");
        }
        //this.image.gameObject.transform.SetParent(Variables.mainUI.transform);
        this.image.transform.position =new Vector3(Random.Range(-175, 175), Random.Range(-175, 175), 0);

        ////this.text.gameObject.transform.SetParent(Variables.mainUI.transform);
        //this.text.transform.position = image.transform.position + new Vector3(125, 125, 0);
        //this.text.text = "+ " + (1 * Variables.clickMultiplier).ToString();

    }
	ShowClickRes SetValues(ShowClickRes res)
    {
        res.image.transform.position = new Vector3(Random.Range(-175, 175), Random.Range(-175, 175), 0);
        return res;

    }
	
	//if (scrapRes.Count < Variables.mPoolMaxSize)
    //        {
    //            ShowClickRes scrap = new ShowClickRes(SortOfRes.scrap);
    //            scrapRes.Add(scrap);
    //            Debug.Log(scrap.image.transform.position + " + + + " + scrap.sortOfRes );
	//
    //        }
    //        else
    //        {
    //            ShowClickRes scrap = scrapRes[Random.Range(0, Variables.mPoolMaxSize)];
    //            Debug.Log("took old scrap");
    //            scrap = SetValues(scrap);
    //            Debug.Log("values set  " + scrap.sortOfRes);
    //        }


}