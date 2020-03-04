using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResearchFacility : MonoBehaviour
{
    private Button button;

    void Start()
    {
        button = this.gameObject.GetComponent<Button>();
        button.onClick.AddListener(IngameUi.EnableResearchFacilityUI);      
    }
}
