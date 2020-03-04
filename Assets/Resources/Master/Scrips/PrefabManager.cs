using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrefabManager : MonoBehaviour
{
    public static Button mainBackground;
    public static Button mainScrapyard;
    public static Button mainGarage;
    public static Button mainResearchFacility;
    public static Image mainResearchFacilityShop;
    public static Image mainGarageMenu;
    public static Button mainFactory;
    public static Button mainWorker;
    public static Image shop;

    private void Awake()
    {
        Variables.mainUI = GameObject.FindGameObjectWithTag("MainUI");

        mainBackground = Resources.Load<Button>("Prefabs/Background");
        mainScrapyard = Resources.Load<Button>("Prefabs/Scrapyard");
        mainGarage = Resources.Load<Button>("Prefabs/Garage");
        mainResearchFacility = Resources.Load<Button>("Prefabs/ResearchFacility");
        mainResearchFacilityShop = Resources.Load<Image>("Prefabs/FacilityShop");
        mainGarageMenu = Resources.Load<Image>("Prefabs/GarageMenu");
        mainFactory = Resources.Load<Button>("Prefabs/Factory");
    }

    void Start ()
    {
        ActivateBackground();
        ActivateScrapyard();
        ActivateGarage();
        ActivateGarageMenu();
        ActivateResearchFacility();
        ActivateFactory();
    }

    #region ActivateUI
    public static void ActivateBackground()
    {
        Button background;
        background = Instantiate(mainBackground);
        background.gameObject.transform.SetParent(Variables.mainUI.transform);
    }

    public static void ActivateScrapyard()
    {
        Button scrapyard;
        scrapyard = Instantiate(mainScrapyard);
        scrapyard.gameObject.transform.SetParent(Variables.mainUI.transform);
        scrapyard.transform.position = new Vector3(506, Screen.height - 720, 0);
    }

    public static void ActivateGarage()
    {
        Button garage;
        garage = Instantiate(mainGarage);
        garage.gameObject.transform.SetParent(Variables.mainUI.transform);
        garage.transform.position = new Vector3(506, 520, 0);
    }

    public static void ActivateGarageMenu()
    {
        Image garageMenu;
        garageMenu = Instantiate(mainGarageMenu);
        garageMenu.gameObject.transform.SetParent(Variables.mainUI.transform);
    }

    public static void ActivateResearchFacility()
    {
        Button researchfacility;
        researchfacility = Instantiate(mainResearchFacility);
        researchfacility.gameObject.transform.SetParent(Variables.mainUI.transform);
        researchfacility.transform.position = Variables.mainUI.transform.position + new Vector3(0, -200, 0);

        shop = Instantiate(mainResearchFacilityShop);
        shop.gameObject.transform.SetParent(Variables.mainUI.transform);
        shop.gameObject.transform.position = Variables.mainUI.transform.position;
        shop.gameObject.SetActive(false);
    }

    public static void ActivateFactory()
    {
        Button factory;
        factory = Instantiate(mainFactory);
        factory.gameObject.transform.SetParent(Variables.mainUI.transform);
    }
    #endregion ActivateUI
}
