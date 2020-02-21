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
        //---------------KILIAN NEU------------//
        Variables.partUI = GameObject.FindGameObjectWithTag("PartUI");
        Variables.carUI = GameObject.FindGameObjectWithTag("CarUI");

        Variables.factoryUI = GameObject.FindGameObjectWithTag("FactoryUI");
        //---------------KILIAN NEU------------ (TAGS WURDEN SCHON HINZUGEFÜGT)--//
    }

    public void Start()
    {
        if (this.gameObject.name.Contains("Scrapyard"))
        {
            
            button = this.gameObject.GetComponent<Button>();
            button.onClick.AddListener(Hauke.ScrapyardClick);
        }

        if (this.gameObject.name.Contains("Background"))
        {
            DisableGarageUI();
            DisableFactoryUI();
        
            //Variables.isIngame = true;
            button = this.gameObject.GetComponent<Button>();
            button.onClick.AddListener(DisableGarageUI);
            button.onClick.AddListener(DisableFactoryUI);
        }

        if (this.gameObject.name.Contains("BuyWorkers"))
        {
            button = this.gameObject.GetComponent<Button>();
            button.onClick.AddListener(BuyWorker);
            Debug.Log("buy whore yes");

        }
        if (this.gameObject.name.Contains("Garage"))
        {
            Debug.Log("BUTTON");
            button = this.gameObject.GetComponent<Button>();
            button.onClick.AddListener(EnableGarageUI);
        }
        //HIER MALTE
        if (this.gameObject.name.Contains("Factory"))
        {
            button = this.gameObject.GetComponent<Button>();
            button.onClick.AddListener(EnableFactoryUI);
        }


        if (this.gameObject.name.Contains("autoteil"))
        {   //BUY PART
            button = this.gameObject.GetComponent<Button>();
            testPart = new Part(SortOfPart.Engine);

            button.onClick.AddListener(delegate { BuyPart(testPart); });
        }
        //---------------KILIAN NEU-------------------------------------------------------------------//
        if (this.gameObject.name.Contains("wagen"))
        {   //BUY CAR
            button = this.gameObject.GetComponent<Button>();
            testCar = new Car(button);
            button.onClick.AddListener(delegate { BuyCar(testCar); }); //****// DELEGATE FÜR ONCLICK //****//
        }
        //---------------KILIAN NEU-------------------------------------------------------------------//
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
        //----added section for de/activating Cars/Parts Ui-----UI needs to be created//
        //----also added function to buy parts ("autoteil")--------------------------//

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
            scraps.text = "Scrap: " + Mathf.RoundToInt(Variables.resScraps).ToString();
            plastics.text = "Plastics: " + Mathf.RoundToInt(Variables.resPlastics).ToString();
            electronics.text = "Electronics: " + Mathf.RoundToInt(Variables.resElectronics).ToString();
            money.text = "$$$: " + Mathf.RoundToInt(Variables.playerMoney).ToString();
            exp.text = "EXP: " + Mathf.RoundToInt(Variables.playerExperience).ToString();
            level.text = "Level: " + Variables.playerLevel;
            selledCars.text = Variables.selledCars.ToString();

            if (Variables.garageUi.activeSelf)
            {

                engines.text = "Engines: " + Mathf.RoundToInt(Variables.partEngines).ToString();
                frames.text = "Frames: " +
                    Mathf.RoundToInt(Variables.partFrames).ToString();
                tires.text = "Tires: " + Mathf.RoundToInt(Variables.partTires).ToString();
            }

        }
        //---------------KILIAN NEU------------------------------showing count of parts--------------------------------//
    }
    public void EnableGarageUI()
    {

        if (!Variables.garageUi.activeSelf)
        {
            Variables.garageUi.SetActive(true);
            //Debug.Log("ENABLE GARAGE UI");
        }
        else
        {
            DisableGarageUI();
        }

    }

    public void UpgradeFactory(int i)
    {
        if (i == 0)
        {
            //engine++
        }
        else if(i == 1)
        {
            //frame++
        }
        else if (i == 2)
        {
            //tire++
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
            //Debug.Log("disable GARAGE UI");
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
            Hauke.ScrapYardCollectorMuliplierCalculation();

        }
    }

    public void BuyPart(Part part)
    { //DELEGATE VERWENDEN FÜR ADDLISTENER

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
            Variables.partTires >= car.requiredTires)
        {

            Variables.selledCars++;
            Variables.partEngines = Variables.partEngines - car.requiredEngines;
            Variables.partFrames = Variables.partFrames - car.requiredFrames;
            Variables.partTires = Variables.partTires - car.requiredTires;

            Variables.playerExperience = Variables.playerExperience + car.expValue;
            Variables.playerMoney = Variables.playerMoney + (car.moneyValue * Variables.carValueMultiplier);
        }

    }

}
