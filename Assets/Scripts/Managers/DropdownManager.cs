using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropdownManager : MonoBehaviour
{
    public GameObject leaderCardsDisplay;
    public GameObject unitCardsDisplay;
    public GameObject spellCardsDisplay;

    void Start()
    {
        var dropdown = transform.GetComponent<Dropdown>();

        dropdown.onValueChanged.AddListener(delegate { ChangeCardsDisplayed(dropdown); });
    }

    void ChangeCardsDisplayed(Dropdown dropdown)
    {
        int index = dropdown.value;

        if (dropdown.options[index].text == "Leaders")
        {
            unitCardsDisplay.SetActive(false);
            spellCardsDisplay.SetActive(false);
            leaderCardsDisplay.SetActive(true);
        }
        else if (dropdown.options[index].text == "Units")
        {
            unitCardsDisplay.SetActive(true);
            spellCardsDisplay.SetActive(false);
            leaderCardsDisplay.SetActive(false);
        }
        else if (dropdown.options[index].text == "Spells")
        {
            unitCardsDisplay.SetActive(false);
            spellCardsDisplay.SetActive(true);
            leaderCardsDisplay.SetActive(false);
        }
    }
}
