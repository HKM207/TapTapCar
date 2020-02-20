using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IngameUi : MonoBehaviour
{
    public Button button;

    public Text scraps;
    public Text electronics;
    public Text plastics;

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
    private void Update()
    {
        if (this.gameObject.name.Contains("Ui"))
        {
            scraps.text = "Scrap: " + Mathf.RoundToInt(Variables.resScraps).ToString();
            electronics.text = "Electronics: " + Mathf.RoundToInt(Variables.resElectronics).ToString();
            plastics.text = "Plastics: " + Mathf.RoundToInt(Variables.resPlastics).ToString();

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
