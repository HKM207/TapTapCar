using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scrapyard : MonoBehaviour
{
    private Button button;
    public Button button2;
    public static Vector3 scrapyardPosition;

    public static Image scrapDisplay;
    public static Image electronicsDisplay;
    public static Image plasticsDisplay;
    public static Text displayText;

    void Awake()
    {
        scrapDisplay = Resources.Load<Image>("Prefabs/ScrapImage");
        electronicsDisplay = Resources.Load<Image>("Prefabs/ElectronicsImage");
        plasticsDisplay = Resources.Load<Image>("Prefabs/PlasticsImage");
        displayText = Resources.Load<Text>("Prefabs/DisplayText");
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
        Image scrap;
        Text text;
        scrap = Instantiate(scrapDisplay);
        scrap.gameObject.transform.SetParent(Variables.mainUI.transform);
        scrap.transform.position = scrapyardPosition + new Vector3(Random.Range(-175, 175), Random.Range(-175, 175), 0);
        text = Instantiate(displayText);
        text.gameObject.transform.SetParent(Variables.mainUI.transform);
        text.transform.position = scrap.transform.position + new Vector3(0, 125, 0);
        text.text = "+ " + (1 * Variables.clickMultiplier).ToString();
    }
    public static void DisplayElectronicClick()
    {
        Image electronic;
        Text text;
        electronic = Instantiate(electronicsDisplay);
        electronic.gameObject.transform.SetParent(Variables.mainUI.transform);
        electronic.transform.position = scrapyardPosition;
        electronic.transform.position = scrapyardPosition + new Vector3(Random.Range(-175, 175), Random.Range(-175, 175), 0);
        text = Instantiate(displayText);
        text.gameObject.transform.SetParent(Variables.mainUI.transform);
        text.transform.position = electronic.transform.position + new Vector3(0, 125, 0);
        text.text = "+ " + (1 * Variables.clickMultiplier).ToString();
    }
    public static void DisplayPlasticsClick()
    {
        Image plastics;
        Text text;
        plastics = Instantiate(plasticsDisplay);
        plastics.gameObject.transform.SetParent(Variables.mainUI.transform);
        plastics.transform.position = scrapyardPosition + new Vector3(Random.Range(-175, 175), Random.Range(-175, 175), 0);
        text = Instantiate(displayText);
        text.gameObject.transform.SetParent(Variables.mainUI.transform);
        text.transform.position = plastics.transform.position + new Vector3(0, 125, 0);
        text.text = "+ " + (1 * Variables.clickMultiplier).ToString();
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
