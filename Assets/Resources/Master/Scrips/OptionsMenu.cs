using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    private void Start()
    {
        hideOptionsButton = hideOptions.gameObject.GetComponent<Button>();
        hideOptionsButton.onClick.AddListener(IngameUi.DisableOptionUI);

        expandingButton = expanding.gameObject.GetComponent<Button>();
        expandingButton.onClick.AddListener(Hauke.ExpendingReset);

        hardResetButton = hardReset.gameObject.GetComponent<Button>();
        hardResetButton.onClick.AddListener(Hauke.HardReset);

        exitButton = exit.gameObject.GetComponent<Button>();
        exitButton.onClick.AddListener(ALTF4);
    }

    public static void ALTF4()
    {
        Application.Quit();       
        Debug.Log("spiel verlasen");
    }

    public Button hideOptions;
    private Button hideOptionsButton;
    public Button expanding;
    private Button expandingButton;
    public Button hardReset;
    private Button hardResetButton;
    public Button exit;
    private Button exitButton;
    public Toggle music;
    private Toggle musicToggle;
    public Toggle sounds;
    private Toggle soundsToggle;
    public Text allTimeStats;
}
