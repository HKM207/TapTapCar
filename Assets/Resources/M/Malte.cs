using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class Malte
{
    private static string saveFileName = "save.save";



    #region Saving and loading
    public static void LoadNewGame()
    {
        SceneManager.LoadScene("Ingame");
    }

    public static void LoadGame()
    {
        CreateDontDestroy.isNewGame = false;
        SceneManager.LoadScene("Ingame");
    }

    public static void SaveGame()
    {
        string path = Application.dataPath;
        path += "/Resources/data/" + saveFileName;
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file;

        SaveGame saveObject = new SaveGame(Variables.resScraps,
        Variables.resElectronics,
        Variables.resPlastics,
        Variables.playerLevel,
        Variables.playerMoney,
        Variables.playerExperience,
        Variables.clickMultiplier);
       

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
        path += "/Resources/data/" + saveFileName;
        if (File.Exists(path))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(path, FileMode.Open);
            SaveGame save = (SaveGame)bf.Deserialize(file);
            file.Close();
            Variables.resScraps = save.resScraps;
            Variables.resElectronics = save.resElectronics;
            Variables.resPlastics = save.resPlastics;
            
            Variables.playerLevel = save.playerLevel;
            Variables.playerMoney = save.playerMoney;
            Variables.playerExperience = save.playerExperience;
            Variables.clickMultiplier = save.clickMultiplier;
            
            Debug.Log("Loaded!");
            return true;
        }
        else
        {
            Debug.Log("Save failed, saveFile not found");
            return false;
        }
    }
    #endregion

    public static void EscMenu()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            Variables.isPaused = TogglePause();
    }


    public static bool TogglePause()
    {
        if (Time.timeScale == 0f)
        {
            Time.timeScale = 1f;
            return (false);
        }
        else
        {
            Time.timeScale = 0f;
            return (true);
        }
    }

}

[System.Serializable]
public class SaveGame
{

    public float resScraps;
    public float resElectronics;
    public float resPlastics;
    public int playerLevel;
    public float playerMoney;
    public float playerExperience;
    public float clickMultiplier;
   


    public SaveGame(float _resScraps,
    float _resElectronics,
    float _resPlastics,
    int _playerLevel,
    float _playerMoney,
    float _playerExperience,
    float _clickMultiplier)
   
    {
        this.resScraps = _resScraps;
        this.resElectronics = _resElectronics;
        this.resPlastics = _resPlastics;
        this.playerExperience = _playerExperience;
        this.playerLevel = _playerLevel;
        this.playerMoney = _playerMoney;
        this.clickMultiplier = _clickMultiplier;
       
    }

}

