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

    public Text engines;
    public Text frames;
    public Text tires;


    private Part testPart;

    private void Awake()
    {
        Variables.garageUi = GameObject.FindGameObjectWithTag("GarageUI");
        //---------------KILIAN NEU------------//
        Variables.partUI = GameObject.FindGameObjectWithTag("PartUI");
        Variables.carUI = GameObject.FindGameObjectWithTag("CarUI");
        //---------------KILIAN NEU------------ (TAGS WURDEN SCHON HINZUGEFÜGT)--//
    }

    public void Start()
    {
        DisableGarageUI();

        if (this.gameObject.name.Contains("Background"))
        {
            button = this.gameObject.GetComponent<Button>();
            button.onClick.AddListener(DisableGarageUI);
        }
        if (this.gameObject.name.Contains("Garage"))
        {
            button = this.gameObject.GetComponent<Button>();
            button.onClick.AddListener(EnableGarageUI);
        }

        //---------------KILIAN NEU--------------------------------------------------------------------------------//
        if (this.gameObject.name.Contains("autoteil"))
        {   //BUY PART
            button = this.gameObject.GetComponent<Button>();
            testPart = new Part(SortOfPart.Engine, button);
            button.onClick.AddListener(delegate { BuyPart(testPart); });  //****// DELEGATE FÜR ONCLICK //****//
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
        //----added section for de/activating Cars/Parts Ui-----UI needs to be created//
        //----also added function to buy parts ("autoteil")--------------------------//
        //---------------KILIAN NEU-------------------------------------------------------------------//
    }
    private void Update()
    {
        if (this.gameObject.name.Contains("Ui"))
        {
            scraps.text = "Scrap: " + Mathf.RoundToInt(Variables.resScraps).ToString();
            plastics.text = "Plastics: " + Mathf.RoundToInt(Variables.resPlastics).ToString();
            electronics.text = "Electronics: " + Mathf.RoundToInt(Variables.resElectronics).ToString();
            if (Variables.garageUi.activeSelf)
            {

                engines.text = "Engines: " + Variables.partEngines.ToString();
                frames.text = "Frames: " + Variables.partFrames.ToString();
                tires.text = "Tires: " + Variables.partTires.ToString();
            }

        }
        //---------------KILIAN NEU------------------------------showing count of parts--------------------------------//
    }
    public void EnableGarageUI()
    {

        if (!Variables.garageUi.activeSelf)
        {
            Variables.garageUi.SetActive(true);
        }
        else
        {
            Variables.garageUi.SetActive(false);
        }
    }

    public void DisableGarageUI()
    {
        if (Variables.garageUi.activeSelf)
        {
            Variables.garageUi.SetActive(false);
        }
    }

    //---------------KILIAN NEU--------------------------------------------------------------------------------//
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
    //---------------KILIAN NEU--------------------------------------------------------------------------------//
}
