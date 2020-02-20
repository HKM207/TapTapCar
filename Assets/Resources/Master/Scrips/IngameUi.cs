using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IngameUi : MonoBehaviour
{
    public Button button;
    GameObject game;
    public void Start()
    {
        if (this.gameObject.name.Contains("Background"))
        {
            button = this.gameObject.GetComponent<Button>();
            button.onClick.AddListener(Malte.DisableGarageUI);
        }
        if (this.gameObject.name.Contains("Garage"))
        {
            button = this.gameObject.GetComponent<Button>();
            button.onClick.AddListener(Malte.DisplayGarageUI);
        }
    }
}
