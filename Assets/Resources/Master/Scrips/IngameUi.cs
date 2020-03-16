using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IngameUi : MonoBehaviour
{
    private Button button;

    private void Awake()
    {
        Variables.mainUI = GameObject.FindGameObjectWithTag("MainUI");
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
            FillScrollLists();
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
        if (!PrefabManager.garageMenu.gameObject.activeSelf)
        {
            PrefabManager.garageMenu.gameObject.SetActive(true);
        }
        else
        {
            PrefabManager.garageMenu.gameObject.SetActive(false);
        }
    }
    public static void DisableGarageUI()
    {
        if (PrefabManager.garageMenu.gameObject.activeSelf)
        {
            PrefabManager.garageMenu.gameObject.SetActive(false);
        }
    }
    #endregion Garage
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
    public static void FillScrollLists()
    {
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
                    Debug.Log("CARS ScrollList Not Found ");
                }
            }          
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