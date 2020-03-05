using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IngameUi : MonoBehaviour
{
    private Button button;
    private Part testPart;
    private Car testCar;

    private void Awake()
    {
        Variables.mainUI = GameObject.FindGameObjectWithTag("MainUI");
        Variables.garageUi = GameObject.FindGameObjectWithTag("GarageUI");
        Variables.partUI = GameObject.FindGameObjectWithTag("PartUI");
        Variables.factoryUI = GameObject.FindGameObjectWithTag("FactoryUI");
        Variables.carUI = Resources.Load<GameObject>("Prefabs/CarUIElementPrefab");
        Variables.scrollListCars = GameObject.Find("CarUIScrollListContents");
    }
    public void Start()
    {
        #region Buttons
        if (this.gameObject.name.Contains("Garage(Clone)"))
        {
            button = this.gameObject.GetComponent<Button>();
            button.onClick.AddListener(EnableGarageUI);
            if (Variables.cars != null) // Das hier muss die Liste der Cars einlesen und für jedes Car ein Element instantiaten und das Car da rein übergeben.
            {
                foreach (Car car in Variables.cars)
                {
                    //SN: Create the Car UI Elements together with the cars.
                    //GameObject scrollListCars = GameObject.Find("CarUIScrollListContents"); // Script sollte man evtl. direkt an dieses Ding hängen.
                    GameObject element;
                    if (Variables.scrollListCars != null)
                    {
                        element = Instantiate(Variables.carUI);
                        element.transform.SetParent(Variables.scrollListCars.transform);
                        element.GetComponent<CarElement>().SetCarInfos(car);
                    }
                    else
                    {
                        Debug.Log("ScrollList Not Found ");
                    }
                }
                //if (this.gameObject.name.Contains("Craft"+i))
                //{   //BUY CAR
                //    //button = this.gameObject.GetComponent<Button>(); 
                //    testCar = new Car(i);
                //    // button.onClick.AddListener(() => { BuyCar(testCar); }); // statt "delegate" habe ich eine anonyme function genommen, damit es nach profi aussieht.
                //}
                //if (this.gameObject.name.Contains("autoteil"))
                //{
                //    button = this.gameObject.GetComponent<Button>();
                //    testPart = new Part(SortOfPart.Engine);
                //    button.onClick.AddListener(delegate { BuyPart(testPart); });
                //}
                //for (int i = 1; i <= 3; i++)
                //{
                //    if (this.gameObject.name.Contains("wagen" + i))
                //    {
                //        button = this.gameObject.GetComponent<Button>();
                //        testCar = new Car(i);
                //        button.onClick.AddListener(delegate { BuyCar(testCar); });
                //    }
                //}
            }
            else
            {
                Debug.Log("Cars not read");
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
        #endregion Buttons
    }

    #region ResearchFacility
    public static void EnableResearchFacilityUI()
    {
        if (!PrefabManager.shop.gameObject.activeSelf)
        {
            PrefabManager.shop.gameObject.SetActive(true);
            Variables.isResearchFacilityActiv = true;
        }
        else
        {
            PrefabManager.shop.gameObject.SetActive(false);
        }
    }
    public static void DisableResearchFacilityUI()
    {
        if (PrefabManager.shop.gameObject.activeSelf)
        {
            PrefabManager.shop.gameObject.SetActive(false);
        }
    }
    #endregion ResearchFacility
    #region Garage
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
    public static void DisableGarageUI()
    {
        if (Variables.garageUi.activeSelf)
        {
            Variables.garageUi.SetActive(false);
        }
    }
    #endregion Garage
    #region Factory
    public static void EnableFactoryUI()
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
    public static void DisableFactoryUI()
    {
        if (Variables.factoryUI.activeSelf)
        {
            Variables.factoryUI.SetActive(false);
        }
    }
    #endregion Factory
    #region Enable Part/CarUI
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
    #endregion Enable Part/CarUI
    #region Buy Part/Car
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
            Variables.playerLevel >= car.level)
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
    #endregion Buy Part/Car
    #region Options
    public static void EnableOptionUI()
    {
        if (!PrefabManager.optionsScreen.gameObject.activeSelf)
        {
            PrefabManager.optionsScreen.gameObject.SetActive(true);
        }
        else
        {
            DisableOptionUI();
        }
    }
    public static void DisableOptionUI()
    {
        if (PrefabManager.optionsScreen.gameObject.activeSelf)
        {
            PrefabManager.optionsScreen.gameObject.SetActive(false);
        }
    }
    #endregion Options

    void OnGUI()
    {
        if (Variables.isPaused)
        {
            GUILayout.Label("Game is paused!");
            if (GUILayout.Button("Click me to unpause"))
                Variables.isPaused = Malte.TogglePause();
        }
    }
    public static bool DisplayDialogBox(string message, string author)
    {
        GameObject DialogPrefab;
        GameObject DialogGo;
        Text DialogMessage = null;
        Text DialogAuthor = null;
        Button DialogOK = null;
        DialogPrefab = Resources.Load<GameObject>("Prefabs/DialogPrefab");
        if (DialogPrefab != null)
        {
            DialogGo = Instantiate(DialogPrefab);
            DialogGo.transform.position = Variables.mainUI.transform.position;

            DialogGo.transform.SetParent(Variables.mainUI.transform);

            Transform[] transformArray = DialogGo.GetComponentsInChildren<Transform>();
            if (transformArray == null)
            {
                Debug.Log("failed finding children of dialog text");
                return false;
            }
            else
            {
                foreach (Transform item in transformArray)
                {
                    if (item != null && item.gameObject != null)
                    {
                        if (item.gameObject.name == "message")
                        {
                            DialogMessage = item.gameObject.GetComponent<Text>();
                        }
                        else if (item.gameObject.name == "author")
                        {
                            DialogAuthor = item.gameObject.GetComponent<Text>();
                        }
                        else if (item.gameObject.name == "ok")
                        {
                            DialogOK = item.gameObject.GetComponent<Button>();
                        }
                    }
                }
                if (DialogMessage != null && DialogAuthor != null && DialogOK != null)
                {
                    DialogMessage.text = message;
                    DialogAuthor.text = author;
                    DialogOK.onClick.AddListener(delegate { Destroy(DialogGo, 0.1f); });
                    return true;
                }
                else
                {
                    Debug.Log("failed to find message or author");
                    return false;
                }
            }
        }
        else
        {
            Debug.Log("didn't find dialog prefab in Master/Prefabs/DialogPrefab");
            return false;
        }
    }
}