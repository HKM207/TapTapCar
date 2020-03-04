using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsDisplay : MonoBehaviour
{
    private Button button;

    public Text scraps;
    public Text electronics;
    public Text plastics;
    public Text money;
    public Text xp;
    public Text level;
    public Text soldCars;

    private void Start()
    {
        IngameUi.DisableGarageUI();
        IngameUi.DisableFactoryUI();
        IngameUi.DisableResearchFacilityUI();
        button = this.gameObject.GetComponent<Button>();
        button.onClick.AddListener(IngameUi.DisableGarageUI);
        button.onClick.AddListener(IngameUi.DisableFactoryUI);
        button.onClick.AddListener(IngameUi.DisableResearchFacilityUI);
    }
    void Update()
    {
        scraps.text = Mathf.RoundToInt(Variables.resScraps).ToString();
        plastics.text = Mathf.RoundToInt(Variables.resPlastics).ToString();
        electronics.text = Mathf.RoundToInt(Variables.resElectronics).ToString();
        money.text = "$$$: " + Mathf.RoundToInt(Variables.playerMoney).ToString();
        xp.text = "EXP: " + Mathf.RoundToInt(Variables.playerExperience).ToString();
        level.text = "Level: " + Variables.playerLevel;
        soldCars.text = Variables.soldCars.ToString();
    }
}
