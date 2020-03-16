using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataReader : MonoBehaviour
{
    /// <summary>
    /// Space for TextAssets
    /// </summary>
    public TextAsset carTextAsset;
    public TextAsset labTextAssest;
    
    private void Start()
    {
        Variables.cars = JsonHelper.getJsonArray<Car>(carTextAsset);
        Variables.buttonClasses = JsonHelper.getJsonArray<ButtonClass>(labTextAssest);
        Debug.Log(Variables.buttonClasses.Length);
        

    }

}

public class JsonHelper
{
    public static T[] getJsonArray<T>(TextAsset jsonData)
    {
        string jsonString = jsonData.text;
        string newJson = "{ \"array\": " + jsonString + "}";
        Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>>(newJson);
        return wrapper.array;
    }

    [System.Serializable]
    private class Wrapper<T>
    {
        public T[] array;
    }

}

//tried building method for generic array
    //private T[] ReadData<T>(TextAsset jsonData, T[] array)
    //{
    //    string jsonString = jsonData.text;
    //    array = JsonHelper.getJsonArray<T>(jsonString);
        
    //    if (array != null)
    //    {
    //        Debug.Log(array.GetType() + " loaded");
    //    }
    //    else
    //    {
    //        Debug.Log(array.Length + " not loaded");
    //    }
    //    array.GetType();
    //    return array;
    //}
