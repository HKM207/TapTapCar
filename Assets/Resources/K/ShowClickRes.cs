using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum SortOfRes
{
    scrap,
    electronic,
    plastic,
    Money,
    Gems

}
public class ShowClickRes
{
    public static int counter;
    public Image image;
    public Text text;
    public SortOfRes sortOfRes;
    public Vector3 StartPosImage;
    public Vector3 StartPosText;


    public ShowClickRes()
    {

    }
    /// <summary>
    /// Shows Image for Clicks
    /// </summary>
    /// <param name="_sortOfRes"></param>
    public ShowClickRes(SortOfRes _sortOfRes)
    { 

        this.sortOfRes = _sortOfRes;

        counter++;



        this.image = GameObject.Instantiate(Scrapyard.clickImage);

        this.image.gameObject.transform.SetParent(Variables.mainUI.transform);

        this.image.transform.position = GetRandomStartPos(Scrapyard.scrapyardPosition);

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
    public static ShowClickRes SetValues(ShowClickRes res,Vector3 origin)
    {
        res.image.transform.position = GetRandomStartPos(origin);
        res.text.transform.position = res.image.transform.position + new Vector3(0, 125, 0);
        return res;

    }
    public static Vector3 GetRandomStartPos(Vector3 origin)
    {

        Vector3 pos = origin + new Vector3(Random.Range(-175, 175), Random.Range(-175, 175), 0);

        return pos;

    }

    /// <summary>
    /// shows Image for Gifts
    /// </summary>
    /// <param name="_res"></param>
    /// <param name="pos"></param>
    public ShowClickRes(Vector3 pos, SortOfRes _sort)
    { // GIFT SHOWER


        this.sortOfRes = _sort;

        this.image = GameObject.Instantiate(Scrapyard.clickImage);
        this.image.gameObject.transform.SetParent(Variables.mainUI.transform);

        this.image.transform.position = GetRandomStartPos(pos);

        this.text = GameObject.Instantiate(Scrapyard.clickText);
        this.text.gameObject.transform.SetParent(Variables.mainUI.transform);


        this.text.transform.position = image.transform.position + new Vector3(0, 125, 0);


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

}