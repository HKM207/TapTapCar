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

        Variables.garageUi = GameObject.FindGameObjectWithTag("GarageUI");
        //Variables.garageUi.GetComponent<GameObject>();
        //Variables.garageUi.SetActive(false);
        CurrentGamestate = Gamestate.mainMenu;
    }

    private void Update()
    {
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
    public static GameObject garageUi;

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

    public static float clickMultiplier;

    public static int engineLevel;
    public static int tireLevel;
    public static int frameLevel;

    public static float carValueMultiplier;
    //FUCKING VARIABLEN STEHEN
}
