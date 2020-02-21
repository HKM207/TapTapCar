﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Gamestate
{
    mainMenu,
    ingame
}

public class CreateDontDestroy : MonoBehaviour
{
    //ignore
    //bool executed1 = false;

    private GameObject logic;
    private static CreateDontDestroy instance;

    public static Gamestate CurrentGamestate;
    public static bool isNewGame = true;




    private void Awake()
    {

        logic = this.gameObject;
        if (instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);

    }

    private void Start()
    {
        CurrentGamestate = Gamestate.mainMenu;
        //Variables.garageUi.SetActive(false);
    }

    private void Update()
    {

        //if (Variables.isIngame && !executed1)
        //{
        //    Variables.garageUi.SetActive(false);
        //    executed1 = true;
        //}
        if (CurrentGamestate == Gamestate.ingame)
        {

            Variables.timeInSek += Time.deltaTime;
            Variables.timeInTicks = Variables.timeInSek * 4;
            

           
            if (Variables.scrapYardCollector >= 1)
            {
                Hauke.ScrapYardCollector();
            }
            //-----------------------Hauke---------------------------------
            if (Variables.isFactoryActiv)
            {
                Hauke.Factory();
            }
            if (Input.GetKeyDown(KeyCode.F))
            {
                Variables.isFactoryActiv = true;
            }
            //-------------------------------------------------------------
            
        }
        SaveGame();
    }




    //-----------------------MALTE---------------------------//
    private void AudioManager()
    {
        if (CurrentGamestate == Gamestate.mainMenu)
        {
            //play main menu music
        }
        if (CurrentGamestate == Gamestate.ingame)
        {
            //play background music
        }
    }


    public void NewGame()
    {
        CurrentGamestate = Gamestate.ingame;
        Malte.LoadNewGame();
    }
    public void LoadGame()
    {
        if (Malte.LoadGameFromSave())
        {
            CurrentGamestate = Gamestate.ingame;
            Malte.LoadGame();
        }
    }

    void SaveGame()
    {
        if (CurrentGamestate == Gamestate.ingame && Input.GetKeyDown(KeyCode.L))
        {
            Malte.SaveGame();
        }
    }

    //-----------------------MALTE---------------------------//


}
public class Variables
{

    //UI SHIT
    public static bool isIngame = false;

    //---------------KILIAN NEU------------//
    public static GameObject partUI;
    public static GameObject carUI;
    public static GameObject factoryUI;
    //---------------KILIAN NEU------------//
    public static GameObject garageUi;

    //FUCKING VARIABLEN STEHEN
    public static float resScraps;
    public static float resElectronics;
    public static float resPlastics;

    public static float partEngines;
    public static float partFrames;
    public static float partTires;

    public static int playerLevel;
    public static float playerMoney;
    public static float playerExperience;

    public static float clickMultiplier = 1;

    public static int engineLevel;
    public static int tireLevel;
    public static int frameLevel;

    public static float carValueMultiplier = 1;
    public static int workerCost = 5000;
    public static int selledCars = 0;

    //-------------------Ticks-------------------------------------
    public static float timeInSek;
    public static int tickCounter = 1;
    public static float timeInTicks;
    //-------------------------------------------------------------

    //-------------------------------------------------------------
    public static float scrapYardCollectorMultiplier;
    public static int scrapYardCollector;
    public static float startScrapYardCollectorMultiplier = 0.125f;
    //-------------------------------------------------------------

    //--------------------Fabrik-----------------------------------
    public static float engineProductionRatio;
    public static float frameProductionRatio;
    public static float tireProductionRatio;
    public static float startEngineProductionRatio = 0.25f;
    public static float startFrameProductionRatio = 0.25f;
    public static float startTireProductionRatio = 0.25f;
    public static bool isFactoryActiv = false;
    //-------------------------------------------------------------

    //FUCKING VARIABLEN STEHEN
}