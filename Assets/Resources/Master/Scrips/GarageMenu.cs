using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GarageMenu : MonoBehaviour
{
    public Button hideGarage;
    private Button hideGarageButton;

    void Start ()
    {
        hideGarageButton = hideGarage.gameObject.GetComponent<Button>();
        hideGarageButton.onClick.AddListener(IngameUi.DisableGarageUI);
    }
}
