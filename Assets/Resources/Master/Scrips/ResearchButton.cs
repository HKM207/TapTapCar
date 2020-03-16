using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FacilityButton : MonoBehaviour
{
    Button button;
    

    int position = 0;

    private void Start()
    {
        button = this.gameObject.GetComponent<Button>();
        button.onClick.AddListener(DisplayInfo);
    }


    public void DisplayInfo()
    {
        if (!ResearchButtonClick.buttonActive)
        {
            GetButtonPostInList();
            ResearchButtonClick.infoText.SetActive(true);
            ResearchButtonClick.infoText.transform.position = new Vector3(position, 0,0);
            //ResearchButtonClick.UpgradeName.text = Variables.researchButtons[position].upgradeName;
            //ResearchButtonClick.Description.text = Variables.researchButtons[position].description;
        }
        else
        {
            Debug.Log("button opened 2 times?");
        }
    }

    public void GetButtonPostInList()
    {
        int count = 0;
        foreach (Button item in FacilityShop.buttons)
        {
            if (item == this.gameObject.GetComponent<Button>())
            {
                position = count + 1;
            }
            count++;
        }
    }
}
