using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IngameUi : MonoBehaviour
{
    public Button button;

    private void Awake()
    {
        Variables.garageUi = GameObject.FindGameObjectWithTag("GarageUI");  
    }

    public void Start()
    {
        DisableGarageUI();

        if (this.gameObject.name.Contains("Background"))
        {
            button = this.gameObject.GetComponent<Button>();
            button.onClick.AddListener(DisableGarageUI);
        }
        if (this.gameObject.name.Contains("Garage"))
        {
            button = this.gameObject.GetComponent<Button>();
            button.onClick.AddListener(EnableGarageUI);
        }
    }

    public void EnableGarageUI()
    {
        
        if (!Variables.garageUi.activeSelf)
        {
            Variables.garageUi.SetActive(true);
        }
        else
        {
            Variables.garageUi.SetActive(false);
        }
    }

    public void DisableGarageUI()
    {
        if (Variables.garageUi.activeSelf)
        {
            Variables.garageUi.SetActive(false);
        }
    }
}
