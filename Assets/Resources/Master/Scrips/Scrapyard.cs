using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scrapyard : MonoBehaviour
{
    public static List<ShowClickRes> scrapList = new List<ShowClickRes>(Variables.Poolsize);
    public static List<ShowClickRes> electronicList = new List<ShowClickRes>(Variables.Poolsize);
    public static List<ShowClickRes> plasticList = new List<ShowClickRes>(Variables.Poolsize);

    private Button button;
    public Button button2;
    public static Vector3 scrapyardPosition;

    public static Image clickImage;
    public static Text clickText;

    public static Image scrapDisplay;
    public static Image electronicsDisplay;
    public static Image plasticsDisplay;
    public static Text displayText;

    void Awake()
    {
        clickImage = Resources.Load<Image>("Prefabs/ClickImage");
        scrapDisplay = Resources.Load<Image>("Prefabs/ScrapImage");
        electronicsDisplay = Resources.Load<Image>("Prefabs/ElectronicsImage");
        plasticsDisplay = Resources.Load<Image>("Prefabs/PlasticsImage");
        clickText = Resources.Load<Text>("Prefabs/DisplayText");
    }

    private void Start()
    {
        button = this.gameObject.GetComponent<Button>();
        button.onClick.AddListener(Hauke.ScrapyardClick);
        scrapyardPosition = this.gameObject.transform.position;
        button2.onClick.AddListener(BuyWorker);
    }

    public static void DisplayScrapClick()
    {

        ShowClickRes clickRes;
        if (ShowClickRes.counter < scrapList.Capacity)
        {
            clickRes = new ShowClickRes(SortOfRes.scrap);
            scrapList.Add(clickRes);
            Debug.Log("new created: counter: " + ShowClickRes.counter);
        }
        else
        {
            foreach (ShowClickRes res in scrapList)
            {
                if (res.image.gameObject.activeSelf)
                {
                    continue;
                }
                else
                {
                    scrapList.Remove(res);
                    clickRes = res;
                    scrapList.Add(clickRes);
                    clickRes = ShowClickRes.SetValues(clickRes);
                    clickRes.image.gameObject.SetActive(true);
                    clickRes.text.gameObject.SetActive(true);
                    Debug.Log("took one out of list");
                    break;
                }
               

            }


        }

    }
    public static void DisplayElectronicClick()
    {

        ShowClickRes clickRes;
        if (ShowClickRes.counter < electronicList.Capacity)
        {
            clickRes = new ShowClickRes(SortOfRes.electronic);
            electronicList.Add(clickRes);
            Debug.Log("new created electronics " + ShowClickRes.counter);
        }
        else
        {
            foreach (ShowClickRes res in electronicList)
            {
                if (res.image.gameObject.activeSelf)
                {
                    continue;
                }
                else
                {
                    electronicList.Remove(res);
                    clickRes = res;
                    electronicList.Add(clickRes);
                    clickRes = ShowClickRes.SetValues(clickRes);
                    clickRes.image.gameObject.SetActive(true);
                    clickRes.text.gameObject.SetActive(true);
                    Debug.Log("took one out of list");
                    break;
                }


            }


        }
    }
    public static void DisplayPlasticsClick()
    {

        ShowClickRes clickRes;
        if (ShowClickRes.counter < plasticList.Capacity)
        {
            clickRes = new ShowClickRes(SortOfRes.plastic);
            plasticList.Add(clickRes);
            Debug.Log("new created electronics " + ShowClickRes.counter);
        }
        else
        {
            foreach (ShowClickRes res in plasticList)
            {
                if (res.image.gameObject.activeSelf)
                {
                    continue;
                }
                else
                {
                    electronicList.Remove(res);
                    clickRes = res;
                    plasticList.Add(clickRes);
                    clickRes = ShowClickRes.SetValues(clickRes);
                    clickRes.image.gameObject.SetActive(true);
                    clickRes.text.gameObject.SetActive(true);
                    Debug.Log("took one out of list");
                    break;
                }


            }


        }

}
    public static void BuyWorker()
    {
        if (Variables.playerMoney >= Variables.workerCost)
        {
            Variables.playerMoney = Variables.playerMoney - Variables.workerCost;
            Variables.scrapYardCollector++;
            Hauke.ScrapYardWorkerMultiplierCalculation();
        }
        if (Variables.playerMoney < Variables.workerCost)
        {
            Debug.Log("nicht genug moneten");
        }
    }
}
