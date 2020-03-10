using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsDisplay : MonoBehaviour
{
    private Button button;
    private Button optionsbutton;

    public Image multiplierBar;
    public Image multiplierBarParent;
    public static float clickTick = 0;

    public Text scraps;
    public Text electronics;
    public Text plastics;
    public Text money;
    public Text xp;
    public Text level;
    public Text soldCars;
    public Button options;

    private void Start()
    {
        IngameUi.DisableGarageUI();
        IngameUi.DisableFactoryUI();
        IngameUi.DisableResearchFacilityUI();
        button = this.gameObject.GetComponent<Button>();
        button.onClick.AddListener(IngameUi.DisableGarageUI);
        button.onClick.AddListener(IngameUi.DisableFactoryUI);
        button.onClick.AddListener(IngameUi.DisableResearchFacilityUI);
        optionsbutton = options.gameObject.GetComponent<Button>();
        optionsbutton.onClick.AddListener(IngameUi.EnableOptionUI);
    }
    void Update()
    {
        MultiplierBar();

        scraps.text = Mathf.RoundToInt(Variables.resScraps).ToString();
        plastics.text = Mathf.RoundToInt(Variables.resPlastics).ToString();
        electronics.text = Mathf.RoundToInt(Variables.resElectronics).ToString();
        money.text = "$$$: " + Mathf.RoundToInt(Variables.playerMoney).ToString();
        xp.text = "EXP: " + Mathf.RoundToInt(Variables.playerExperience).ToString();
        level.text = "Level: " + Variables.playerLevel;
        soldCars.text = Variables.soldCars.ToString();


    }

    public void MultiplierBar()
    {
        float barWidth = 500;
        float barHeight = 75;
        int tempClicks = 0;
        clickTick = clickTick + Time.deltaTime;
        RectTransform rectTransform = multiplierBar.GetComponent<RectTransform>();
        RectTransform rectTransformParent = multiplierBarParent.GetComponent<RectTransform>();

        if (clickTick >= 3)
        {
            Variables.clicks = 0;
            clickTick = 0;
        }
        if (Variables.clicks <= cmLevel1)
        {
            tempClicks = Variables.clicks;
            rectTransform.sizeDelta = new Vector2((barWidth / cmLevel1) * tempClicks, barHeight);
            rectTransform.position = rectTransformParent.position - new Vector3(barWidth / 2 - (tempClicks * ((barWidth / cmLevel1) / 2)), 0);
            multiplierBar.color = Color.white;
        }
        if (Variables.clicks <= cmLevel2 && Variables.clicks > cmLevel1)
        {
            tempClicks = Variables.clicks - cmLevel1;
            rectTransform.sizeDelta = new Vector2((barWidth / (cmLevel2 - cmLevel1)) * tempClicks, barHeight);
            rectTransform.position = rectTransformParent.position - new Vector3(barWidth / 2 - (tempClicks * ((barWidth / (cmLevel2 - cmLevel1)) / 2)), 0);
            multiplierBar.color = Color.blue;
        }                      
        if (Variables.clicks <= cmLevel3 && Variables.clicks > cmLevel2)
        {
            tempClicks = Variables.clicks - cmLevel2;
            rectTransform.sizeDelta = new Vector2((barWidth / (cmLevel3 - cmLevel2)) * tempClicks, barHeight);
            rectTransform.position = rectTransformParent.position - new Vector3(barWidth / 2 - (tempClicks * ((barWidth / (cmLevel3 - cmLevel2)) / 2)), 0);
            multiplierBar.color = Color.green;                                      
        }
        if (Variables.clicks <= cmLevel4 && Variables.clicks > cmLevel3)
        {
            tempClicks = Variables.clicks - cmLevel3;
            rectTransform.sizeDelta = new Vector2((barWidth / (cmLevel4 - cmLevel3)) * tempClicks, barHeight);
            rectTransform.position = rectTransformParent.position - new Vector3(barWidth / 2 - (tempClicks * ((barWidth / (cmLevel4 - cmLevel3)) / 2)), 0);
            multiplierBar.color = Color.red;
        }
        if (Variables.clicks <= cmLevel5 && Variables.clicks > cmLevel4)
        {
            tempClicks = Variables.clicks - cmLevel4;
            rectTransform.sizeDelta = new Vector2((barWidth / (cmLevel5 - cmLevel4)) * tempClicks, barHeight);
            rectTransform.position = rectTransformParent.position - new Vector3(barWidth / 2 - (tempClicks * ((barWidth / (cmLevel5 - cmLevel4)) / 2)), 0);
            multiplierBar.color = Color.cyan;
        }

        if (Variables.clicks <= cmLevelMax && Variables.clicks > cmLevel5)
        {
            tempClicks = Variables.clicks - cmLevel5;
            rectTransform.sizeDelta = new Vector2((barWidth / (cmLevelMax - cmLevel5)) * tempClicks, barHeight);
            rectTransform.position = rectTransformParent.position - new Vector3(barWidth / 2 - (tempClicks * ((barWidth / (cmLevelMax - cmLevel5)) / 2)), 0);
            multiplierBar.color = Color.yellow;
        }
        if (Variables.clicks >= cmLevelMax)
        {
            multiplierBar.color = Color.magenta;
        }
    }
    private int cmLevel1 = 10;
    private int cmLevel2 = 25;
    private int cmLevel3 = 65;
    private int cmLevel4 = 150;
    private int cmLevel5 = 400;
    private int cmLevelMax = 1000;
}