using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Gamestate
{
    mainMenu,
    ingame
}

public class CreateDontDestroy : MonoBehaviour
{


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
    }

    //-------------------------------------------------------------
    public void Update()
    {
        //---------------------ZeitRythmus-----------------------------
        Variables.timeInSek += Time.deltaTime;
        //Debug.Log(Variables.timeInSek);

        Variables.timeInTicks = Variables.timeInSek * 4;
        //Debug.Log("Ticks " + Variables.timeInTicks);
        //-------------------------------------------------------------


        if (Input.anyKeyDown)
        {
            Hauke.ScrapyardClick();
        }

        if (Variables.scrapYardCollector >= 1)
        {
            Hauke.ScrapYardCollector();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Variables.scrapYardCollector ++;
            Hauke.ScrapYardCollectorMuliplierCalculation();
        }

        Debug.Log("colectors " + Variables.scrapYardCollector);
        Debug.Log("muliplier " + Variables.scrapYardCollectorMultiplier);

        Debug.Log("Anzahl Scrap: " + Variables.resScraps);
        Debug.Log("Anzahl Electronics: " + Variables.resElectronics);
        Debug.Log("Anzahl Plastics: " + Variables.resPlastics);
    }
    //-------------------------------------------------------------


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
        Malte.LoadNewGame();
    }
    public void LoadGame()
    {
        Malte.LoadGame();
    }


}
public class Variables
{
    //-------------------Ticks-----------------------------------
    public static float timeInSek;
    public static float timeInTicks;
    public static int tickCounter = 1;
    //-------------------------------------------------------------

    //FUCKING VARIABLEN STEHEN
    public static float resScraps;
    public static float resElectronics;
    public static float resPlastics;

    public static int partEngines;
    public static int partFrames;
    public static int partTires;

    public static int playerLevel;
    public static float playerMoney;
    public static float playerExperience;

    public static float clickMultiplier = 1;

    public static int engineLevel;
    public static int tireLevel;
    public static int frameLevel;

    public static float carValueMultiplier;
    //FUCKING VARIABLEN STEHEN


    //-------------------------------------------------------------
    public static int scrapYardCollector;
    public static float scrapYardCollectorMultiplier;
    public static float startScrapYardCollectorMultiplier = 0.125f;
    //-------------------------------------------------------------
}
