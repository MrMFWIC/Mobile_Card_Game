using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DuelSetupDropdownManager : MonoBehaviour
{
    public Dropdown deckResourcesDropdown;
    public Dropdown roundResourcesDropdown;
    public Dropdown healthPointsDropdown;

    void Start()
    {
        deckResourcesDropdown.onValueChanged.AddListener(delegate { ChangeDeckResources(deckResourcesDropdown); });
        roundResourcesDropdown.onValueChanged.AddListener(delegate { ChangeRoundResources(roundResourcesDropdown); });
        healthPointsDropdown.onValueChanged.AddListener(delegate { ChangeHealthPoints(healthPointsDropdown); });
    }

    void ChangeDeckResources(Dropdown dropdown)
    {
        int index = dropdown.value;
        int value = int.Parse(dropdown.options[index].text);

        GameManager.instance.deckResources = value;
    }

    void ChangeRoundResources(Dropdown dropdown)
    {
        int index = dropdown.value;
        int value = int.Parse(dropdown.options[index].text);

        GameManager.instance.roundResources = value;
    }

    void ChangeHealthPoints(Dropdown dropdown)
    {
        int index = dropdown.value;
        int value = int.Parse(dropdown.options[index].text);

        GameManager.instance.healthPool = value;
    }
}
