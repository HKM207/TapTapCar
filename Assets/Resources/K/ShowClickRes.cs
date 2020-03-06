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
    public static int counter = 0;
    public Image image;
    public Text text;
    public SortOfRes sortOfRes;
    public Vector3 StartPosImage;
    public Vector3 StartPosText;


    public ShowClickRes()
    {

    }
    public ShowClickRes(SortOfRes _sortOfRes)
    {

        this.sortOfRes = _sortOfRes;

        ++counter;



        this.image = GameObject.Instantiate(Scrapyard.clickImage);

        this.image.gameObject.transform.SetParent(Variables.mainUI.transform);

        this.image.transform.position = GetRandomStartPos();

        this.text = GameObject.Instantiate(Scrapyard.clickText);
        this.text.gameObject.transform.SetParent(Variables.mainUI.transform);

        
        this.text.transform.position = image.transform.position + new Vector3(0, 125, 0);

        this.text.text = "+ " + (1 * Variables.clickMultiplier).ToString();
        


        if (this.sortOfRes == SortOfRes.scrap)
        {
            Sprite sprite = Resources.Load<Sprite>("Master/ConceptGraphics/scrap");
            this.image.GetComponent<Image>().sprite = sprite;


        }
        else if (this.sortOfRes == SortOfRes.electronic)
        {
            Sprite sprite = Resources.Load<Sprite>("Master/ConceptGraphics/electronics");
            this.image.GetComponent<Image>().sprite = sprite;

        }
        else if (this.sortOfRes == SortOfRes.plastic)
        {
            Sprite sprite = Resources.Load<Sprite>("Master/ConceptGraphics/plastics");
            this.image.GetComponent<Image>().sprite = sprite;

        }
        else
        {
            Debug.Log("no SortOfRes Defined");
        }

    }
    public static ShowClickRes SetValues(ShowClickRes res)
    {
        res.image.transform.position = GetRandomStartPos();
        res.text.transform.position = res.image.transform.position + new Vector3(0, 125, 0);
        Debug.Log("ValuesSet " + res.image.transform.position);
        return res;

    }
    public static Vector3 GetRandomStartPos()
    {

        Vector3 pos = Scrapyard.scrapyardPosition + new Vector3(Random.Range(-175, 175), Random.Range(-175, 175), 0);

        return pos;

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