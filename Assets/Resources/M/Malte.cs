using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class Malte
{
    private static string saveFileName = "save.save";


    public static void LoadNewGame()
    {
        SceneManager.LoadScene("Ingame");
    }

    public static void LoadGame()
    {
        CreateDontDestroy.isNewGame = false;
        SceneManager.LoadScene("Ingame");
    }


    public static void DisplayGarageUI()
    {
        Variables.garageUi = Variables.garageUi.GetComponent<GameObject>();
        if (!Variables.garageUi.activeSelf)
        {
            Variables.garageUi.SetActive(true);
        }
    }

    public static void DisableGarageUI()
    {
        Variables.garageUi = Variables.garageUi.GetComponent<GameObject>();
        
        if (Variables.garageUi.activeSelf)
        {
            Variables.garageUi.SetActive(false);
        }   
    }

    public static void SaveGame()
    {
        string path = Application.dataPath;
        path += "/data/" + saveFileName;
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file;

        SaveGame saveObject = new SaveGame(Variables.resScraps,
        Variables.resElectronics,
        Variables.resPlastics,
        Variables.partEngines,
        Variables.partFrames,
        Variables.partTires,
        Variables.playerLevel,
        Variables.playerMoney,
        Variables.playerExperience,
        Variables.clickMultiplier,
        Variables.engineLevel,
        Variables.tireLevel,
        Variables.frameLevel);

        if (File.Exists(path))
        {
            file = File.Open(path, FileMode.Open);
            bf.Serialize(file, saveObject);
            file.Close();
            Debug.Log(saveFileName + " overitten in " + path);
        }
        else
        {
            file = File.Create(path);
            bf.Serialize(file, saveObject);
            file.Close();
            Debug.Log(saveFileName + " Created and saved in" + path);
        }

    }

    public static bool LoadGameFromSave()
    {
        string path = Application.dataPath;
        path += "/data/" + saveFileName;
        if (File.Exists(path))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(path , FileMode.Open);
            SaveGame save = (SaveGame)bf.Deserialize(file);
            file.Close();
            Variables.resScraps = save.resScraps;
            Variables.resElectronics = save.resElectronics;
            Variables.resPlastics = save.resPlastics;
            Variables.partEngines = save.partEngines;
            Variables.partFrames = save.partFrames;
            Variables.partTires = save.partTires;
            Variables.playerLevel = save.playerLevel;
            Variables.playerMoney = save.playerMoney;
            Variables.playerExperience = save.playerExperience;
            Variables.clickMultiplier = save.clickMultiplier;
            Variables.engineLevel = save.engineLevel;
            Variables.tireLevel = save.tireLevel;
            Variables.frameLevel = save.frameLevel;
            Debug.Log("Loaded!");
            return true;
        }
        else
        {
            Debug.Log("Save failed, saveFile not found");
            return false;
        }
    }

}

[System.Serializable]
public class SaveGame
{

    public float resScraps;
    public float resElectronics;
    public float resPlastics;
    public int partEngines;
    public int partFrames;
    public int partTires;
    public int playerLevel;
    public float playerMoney;
    public float playerExperience;
    public float clickMultiplier;
    public int engineLevel;
    public int tireLevel;
    public int frameLevel;


    public SaveGame(float _resScraps,
    float _resElectronics,
    float _resPlastics,
    int _partEngines,
    int _partFrames,
    int _partTires,
    int _playerLevel,
    float _playerMoney,
    float _playerExperience,
    float _clickMultiplier,
    int _engineLevel,
    int _tireLevel,
    int _frameLevel)
    {
        this.resScraps = _resScraps;
        this.resElectronics = _resElectronics;
        this.resPlastics = _resPlastics;
        this.partEngines = _partEngines;
        this.partFrames = _partFrames;
        this.partTires = _partTires;
        this.playerExperience = _playerExperience;
        this.playerLevel = _playerLevel;
        this.playerMoney = _playerMoney;
        this.clickMultiplier = _clickMultiplier;
        this.engineLevel = _engineLevel;
        this.tireLevel = _tireLevel;
        this.frameLevel = _frameLevel;
    }

}
