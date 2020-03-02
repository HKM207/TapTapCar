using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class JsonReader : MonoBehaviour {

    string jsonString;
    public TextAsset jsonTextAsset;
    public static Car[] cars;



    void Start()
    {
        ReadData();
    }

    private void ReadData()
    {
        jsonString = jsonTextAsset.text;
        cars = JsonHelper.getJsonArray<Car>(jsonString);

        //*****access to all attributes of the json objects(cars)******//
        foreach (Car c in cars)
        {
            
            Debug.Log(c.level);
            Debug.Log(c.name +": "+c.moneyValue);
        }
        //*****access to all attributes of the json objects(cars)******//
    }


}



public class JsonHelper
{
    public static T[] getJsonArray<T>(string json)
    {
        string newJson = "{ \"array\": " + json + "}";
        Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>>(newJson);
        return wrapper.array;
    }

    [System.Serializable]
    private class Wrapper<T>
    {
        public T[] array;
    }

}
