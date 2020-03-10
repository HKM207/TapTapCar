using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataReader : MonoBehaviour {

    string jsonString;
    public TextAsset carTextAsset;
    public TextAsset partTextAsset;
    
    
    void Start()
    {
        ReadCarData();
        //ReadPartData();
    }

    private void ReadCarData()
    {
        Variables.cars = JsonHelper.getJsonArray<Car>(carTextAsset.text);

        if (Variables.cars != null)
        {
            Debug.Log("Cars succesfully read");
        }
        else
        {
            Debug.Log("Cars not read");
        }
    }
    //private void ReadPartData()
    //{
    //    Variables.parts = JsonHelper.getJsonArray<Part>(partTextAsset.text);

    //    if (Variables.parts != null)
    //    {
    //        Debug.Log("Parts succesfully read");
    //    }
    //    else
    //    {
    //        Debug.Log("Parts not read");
    //    }
    //}


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
