using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IngameUi : MonoBehaviour
{
    private Button button;

    public Text scraps;
    public Text electronics;
    public Text plastics;
    public Text money;
    public Text exp;
    public Text level;
    public Text selledCars;

    public Text engines;
    public Text frames;
    public Text tires;


    private Part testPart;
    private Car testCar;


    private void Awake()
    {
        Variables.garageUi = GameObject.FindGameObjectWithTag("GarageUI");
        Variables.partUI = GameObject.FindGameObjectWithTag("PartUI");
        Variables.carUI = GameObject.FindGameObjectWithTag("CarUI");
        Variables.factoryUI = GameObject.FindGameObjectWithTag("FactoryUI");

    }

    public void Start()
    {   
        //SWITCHCASE
        if (this.gameObject.name.Contains("Scrapyard"))
        {
            button = this.gameObject.GetComponent<Button>();
            button.onClick.AddListener(Hauke.ScrapyardClick);
        }
        if (this.gameObject.name.Contains("Background"))
        {
            DisableGarageUI();
            DisableFactoryUI();
            button = this.gameObject.GetComponent<Button>();
            button.onClick.AddListener(DisableGarageUI);
            button.onClick.AddListener(DisableFactoryUI);
        }
        if (this.gameObject.name.Contains("BuyWorkers"))
        {
            button = this.gameObject.GetComponent<Button>();
            button.onClick.AddListener(BuyWorker);
        }
        if (this.gameObject.name.Contains("Garage"))
        {
            button = this.gameObject.GetComponent<Button>();
            button.onClick.AddListener(EnableGarageUI);
        }
        if (this.gameObject.name.Contains("Factory"))
        {
            button = this.gameObject.GetComponent<Button>();
            button.onClick.AddListener(EnableFactoryUI);
        }
        if (this.gameObject.name.Contains("autoteil"))
        { 
            button = this.gameObject.GetComponent<Button>();
            testPart = new Part(SortOfPart.Engine);
            button.onClick.AddListener(delegate { BuyPart(testPart); });
        }
        for (int i = 1; i <= 3; i++)
        {
            if (this.gameObject.name.Contains("wagen"+i))
            {   //BUY CAR
                button = this.gameObject.GetComponent<Button>();
                testCar = new Car(button, i);
                button.onClick.AddListener(delegate { BuyCar(testCar); });
            }
        }
        if (this.gameObject.name.Contains("Parts"))
        {
            button = this.gameObject.GetComponent<Button>();
            button.onClick.AddListener(EnablePartUI);
        }
        if (this.gameObject.name.Contains("Cars"))
        {
            button = this.gameObject.GetComponent<Button>();
            button.onClick.AddListener(EnableCarUI);
        }
        if (this.gameObject.name.Contains("EngineProduction"))
        {
            button = this.gameObject.GetComponent<Button>();
            button.onClick.AddListener(delegate { UpgradeFactory(0); });
        }
        if (this.gameObject.name.Contains("FrameProduction"))
        {
            button = this.gameObject.GetComponent<Button>();
            button.onClick.AddListener(delegate { UpgradeFactory(1); });
        }
        if (this.gameObject.name.Contains("TireProduction"))
        {
            button = this.gameObject.GetComponent<Button>();
            button.onClick.AddListener(delegate { UpgradeFactory(2); });
        }
        if (this.gameObject.name.Contains("CarProduction1"))
        {
            button = this.gameObject.GetComponent<Button>();
            button.onClick.AddListener(delegate { UpgradeFactory(3); });
        }
    }
    private void Update()
    {
        if (this.gameObject.name.Contains("Ui"))
        {
            scraps.text = Mathf.RoundToInt(Variables.resScraps).ToString();
            plastics.text = Mathf.RoundToInt(Variables.resPlastics).ToString();
            electronics.text = Mathf.RoundToInt(Variables.resElectronics).ToString();
            money.text = "$$$: " + Mathf.RoundToInt(Variables.playerMoney).ToString();
            exp.text = "EXP: " + Mathf.RoundToInt(Variables.playerExperience).ToString();
            level.text = "Level: " + Variables.playerLevel;
            selledCars.text = Variables.soldCars.ToString();

            if (Variables.garageUi.activeSelf)
            {
                engines.text = "Engines: " + Mathf.RoundToInt(Variables.partEngines).ToString();
                frames.text = "Frames: " + Mathf.RoundToInt(Variables.partFrames).ToString();
                tires.text = "Tires: " + Mathf.RoundToInt(Variables.partTires).ToString();
            }
        }

    }
    public void EnableGarageUI()
    {
        if (!Variables.garageUi.activeSelf)
        {
            Variables.garageUi.SetActive(true);
        }
        else
        {
            DisableGarageUI();
        }
    }
    public void UpgradeFactory(int i)
    {
        //SWITCHCASE
        if (i == 0)
        {
            Variables.isFactoryActiv = true;
            Hauke.FactoryCostsCalculation();
            if (Variables.playerMoney >= Variables.factoryCost)
            {
                Variables.playerMoney = Variables.playerMoney - Variables.factoryCost;
                Variables.engineProductionRatio = Variables.engineProductionRatio + 0.1f;
                Variables.factoryUpgrades++;
            }
            else
            {
                Debug.Log("kein geld für fabrik");
            }
        }
        else if(i == 1)
        {
            Variables.isFactoryActiv = true;
            Hauke.FactoryCostsCalculation();
            if (Variables.playerMoney >= Variables.factoryCost)
            {
                Variables.playerMoney = Variables.playerMoney - Variables.factoryCost;
                Variables.frameProductionRatio = Variables.frameProductionRatio + 0.1f;
                Variables.factoryUpgrades++;
            }
            else
            {
                Debug.Log("kein geld für fabrik");
            }
        }
        else if (i == 2)
        {
            Variables.isFactoryActiv = true;
            Hauke.FactoryCostsCalculation();
            if (Variables.playerMoney >= Variables.factoryCost)
            {
                Variables.playerMoney = Variables.playerMoney - Variables.factoryCost;
                Variables.tireProductionRatio = Variables.tireProductionRatio + 0.1f;
                Variables.factoryUpgrades++;
            }
            else
            {
                Debug.Log("kein geld für fabrik");
            }
        }
        else if( i == 3)
        {
            //car++
        }
        else 
        {
            Debug.Log("error 2 many buttonss");
        }
    }
    public void DisableGarageUI()
    {
        if (Variables.garageUi.activeSelf)
        {
            Variables.garageUi.SetActive(false);
        }
    }
    public void EnableFactoryUI()
    {
        if (!Variables.factoryUI.activeSelf)
        {
            Variables.factoryUI.SetActive(true);
        }
        else
        {
            Variables.factoryUI.SetActive(false);
        }
    }
    public void DisableFactoryUI()
    {
        if (Variables.factoryUI.activeSelf)
        {
            Variables.factoryUI.SetActive(false);
        }
    }
    public void EnablePartUI()
    {
        if (Variables.garageUi.activeSelf)
        {
            Variables.carUI.SetActive(false);
            Variables.partUI.SetActive(true);
        }
    }
    public void EnableCarUI()
    {
        if (Variables.garageUi.activeSelf)
        {
            Variables.partUI.SetActive(false);
            Variables.carUI.SetActive(true);
        }
    }
    void BuyWorker()
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
    public void BuyPart(Part part)
    {
        if (Variables.resScraps >= part.requiredScrap &&
            Variables.resPlastics >= part.requiredPlastics &&
            Variables.resElectronics >= part.requiredElectronics)
        {
            Variables.resScraps = Variables.resScraps - part.requiredScrap;
            Variables.resPlastics = Variables.resPlastics - part.requiredPlastics;
            Variables.resElectronics = Variables.resElectronics - part.requiredElectronics;

            if (part.sort == SortOfPart.Engine)
            {
                Variables.partEngines++;
            }
            else if (part.sort == SortOfPart.Frame)
            {
                Variables.partFrames++;
            }
            else if (part.sort == SortOfPart.Tire)
            {
                Variables.partTires++;
            }
        }
    }
    public void BuyCar(Car car)
    {
        if (Variables.partEngines >= car.requiredEngines &&
            Variables.partFrames >= car.requiredFrames &&
            Variables.partTires >= car.requiredTires &&
            Variables.playerLevel >= car.requiredLevel)
        {
            Variables.soldCars++;
            Variables.partEngines = Variables.partEngines - car.requiredEngines;
            Variables.partFrames = Variables.partFrames - car.requiredFrames;
            Variables.partTires = Variables.partTires - car.requiredTires;

            Variables.playerExperience = Variables.playerExperience + car.expValue;
            Variables.playerMoney = Variables.playerMoney + (car.moneyValue * Variables.carValueMultiplier);
            Variables.playerMoneyTotel = Variables.playerMoneyTotel + (car.moneyValue * Variables.carValueMultiplier);
        }
    }


    void OnGUI()
    {
        if (Variables.isPaused)
        {
            GUILayout.Label("Game is paused!");
            if (GUILayout.Button("Click me to unpause"))
                Variables.isPaused = Malte.TogglePause();
        }
    }
}
