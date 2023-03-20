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

    private CanvasManager canvasManager;

    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(() => ShowCardDetails());

        UpdateCard();

        canvasManager = UnityEngine.Object.FindObjectOfType<Canvas>().GetComponent<CanvasManager>();
    }

    void ShowCardDetails()
    {
        if (!canvasManager.cardDetailsMenu.activeInHierarchy)
        {
            canvasManager.cardDetailsMenu.SetActive(true);
            
            //Show Correct Details Panel
            if (card.currentCardType == Card.cardType.Spell)
            {
                canvasManager.unitDetailsPanel.SetActive(false);
                canvasManager.spellDetailsPanel.SetActive(true);
            }
            else
            {
                canvasManager.unitDetailsPanel.SetActive(true);
                canvasManager.spellDetailsPanel.SetActive(false);
            }

            //Show Card Selected in Card Details Menu
            var cardDisplay = canvasManager.cardDetailsMenu.gameObject.GetComponentInChildren<CardDisplay>();
            cardDisplay.card = card;
            cardDisplay.UpdateCard();

            //Show Card Details 
            canvasManager.cardNameText.text = card.name;
            canvasManager.cardTypeText.text = card.currentCardType.ToString();
            canvasManager.cardAffiliationText.text = card.affiliationtext;
            canvasManager.cardATKText.text = card.ATK.ToString();
            canvasManager.cardCostText.text = card.cost.ToString();
            canvasManager.cardLoreText.text = card.loreText;
            canvasManager.cardEffectText.text = card.bonusEffectText;
        }

        if (canvasManager.cardDetailsMenu.activeInHierarchy && SceneManager.GetSceneByName("Arena").isLoaded)
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
