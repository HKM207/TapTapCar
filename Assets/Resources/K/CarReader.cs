using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class CarReader : MonoBehaviour {

    string jsonString;
    public TextAsset jsonTextAsset;
    
    
    void Start()
    {
        ReadData();
    }

    private void ReadData()
    {
        jsonString = jsonTextAsset.text;
        Variables.cars = JsonHelper.getJsonArray<Car>(jsonString);

        if (Variables.cars != null)
        {
            Debug.Log("Cars succesfully read");
        }
        else
        {
            Debug.Log("Cars not read");
        }
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
