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
    public static Image garageMenu;
    public static Image options;
    public static Image optionsScreen;

    private void Awake()
    {
        Variables.mainUI = GameObject.FindGameObjectWithTag("MainUI");

        mainBackground = Resources.Load<Button>("Prefabs/Background");
        mainScrapyard = Resources.Load<Button>("Prefabs/Scrapyard");
        mainGarage = Resources.Load<Button>("Prefabs/Garage");
        mainResearchFacility = Resources.Load<Button>("Prefabs/ResearchFacility");
        mainResearchFacilityShop = Resources.Load<Image>("Prefabs/FacilityShop");
        mainGarageMenu = Resources.Load<Image>("Prefabs/GarageMenu");
        options = Resources.Load<Image>("Prefabs/Options");
    }

    void Start ()
    {
        ActivateBackground();
        ActivateScrapyard();
        ActivateGarage();
        ActivateResearchFacility();
        ActivateGarageMenu();
        ActivateOptions();
    }

    #region ActivateUI
    public static Button ResetValues(Button button)
    {
        RectTransform rect = button.GetComponent<RectTransform>();       
        rect.gameObject.transform.SetParent(Variables.mainUI.transform);
        rect.offsetMin = rect.offsetMax = Vector2.zero;
        rect.localScale = new Vector3(1, 1, 1);
        return button;
    }

    public static Image ResetValuesImage(Image image)
    {
        RectTransform rect = image.GetComponent<RectTransform>();
        rect.gameObject.transform.SetParent(Variables.mainUI.transform);
        rect.offsetMin = rect.offsetMax = Vector2.zero;
        rect.localScale = new Vector3(1, 1, 1);
        return image;
    }

    public static void ActivateBackground()
    {
        Button background;
        background = Instantiate(mainBackground);
        background = ResetValues(background);
    }

    public static void ActivateScrapyard()
    {
        Button scrapyard;
        scrapyard = Instantiate(mainScrapyard);
        scrapyard = ResetValues(scrapyard); 
    }

    public static void ActivateGarage()
    {
        Button garage;
        garage = Instantiate(mainGarage);
        garage = ResetValues(garage);
        garage.onClick.AddListener(IngameUi.EnableGarageUI);
        IngameUi.FillScrollLists();
    }

    public static void ActivateGarageMenu()
    {
        garageMenu = Instantiate(mainGarageMenu);
        garageMenu = ResetValuesImage(garageMenu);
        garageMenu.gameObject.SetActive(false);
    }

    public static void ActivateResearchFacility()
    {
        Button researchfacility;
        researchfacility = Instantiate(mainResearchFacility);
        researchfacility = ResetValues(researchfacility);

        shop = Instantiate(mainResearchFacilityShop);
        shop = ResetValuesImage(shop);
        shop.gameObject.SetActive(false);
    }

    public static void ActivateOptions()
    {
        optionsScreen = Instantiate(options);
        optionsScreen = ResetValuesImage(optionsScreen);
        optionsScreen.gameObject.SetActive(false);
    }
    #endregion ActivateUI
}
