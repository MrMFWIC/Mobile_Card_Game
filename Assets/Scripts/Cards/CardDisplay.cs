using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CardDisplay : MonoBehaviour
{
    public Card card;
    public Button button;

    public Text nameText;
    public Text descriptionText;
    public Text costText;
    public Text ATKText;

    public Image artworkImage;
    public Image cardFrameImage;

    public Image ATKPlaceholderImage;

    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(() => ShowCardDetails());

        UpdateCard();
    }

    void ShowCardDetails()
    {
        if (!CanvasManager.instance.cardDetailsMenu.activeInHierarchy)
        {
            CanvasManager.instance.cardDetailsMenu.SetActive(true);
            
            //Show Correct Details Panel
            if (card.currentCardType == Card.cardType.Spell)
            {
                CanvasManager.instance.unitDetailsPanel.SetActive(false);
                CanvasManager.instance.spellDetailsPanel.SetActive(true);
            }
            else
            {
                CanvasManager.instance.unitDetailsPanel.SetActive(true);
                CanvasManager.instance.spellDetailsPanel.SetActive(false);
            }

            //Show Card Selected in Card Details Menu
            var cardDisplay = CanvasManager.instance.cardDetailsMenu.gameObject.GetComponentInChildren<CardDisplay>();
            cardDisplay.card = card;
            cardDisplay.UpdateCard();

            //Show Card Details 
            CanvasManager.instance.cardNameText.text = card.name;
            CanvasManager.instance.cardTypeText.text = card.currentCardType.ToString();
            CanvasManager.instance.cardAffiliationText.text = card.affiliationtext;
            CanvasManager.instance.cardATKText.text = card.ATK.ToString();
            CanvasManager.instance.cardCostText.text = card.cost.ToString();
            CanvasManager.instance.cardLoreText.text = card.loreText;
            CanvasManager.instance.cardEffectText.text = card.bonusEffectText;
        }

        if (CanvasManager.instance.cardDetailsMenu.activeInHierarchy && SceneManager.GetSceneByName("Arena").isLoaded)
        {
            //Play Card
        }
    }

    void UpdateCard()
    {
        nameText.text = card.name;
        descriptionText.text = card.description;
        costText.text = card.cost.ToString();
        ATKText.text = card.ATK.ToString();

        artworkImage.sprite = card.artwork;
        cardFrameImage.sprite = card.cardFrame;

        if (card.currentCardType == Card.cardType.Spell)
        {
            ATKPlaceholderImage.enabled = false;
            ATKText.enabled = false;
        }
    }
}
