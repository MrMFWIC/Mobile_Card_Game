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
        canvasManager = UnityEngine.Object.FindObjectOfType<Canvas>().GetComponent<CanvasManager>();

        if (!canvasManager.cardDetailsMenu.activeInHierarchy)
        {
            canvasManager.cardDetailsMenu.SetActive(true);
            
            //Show Correct Details Panel With Information
            if (card.currentCardType == Card.cardType.Spell)
            {
                canvasManager.unitDetailsPanel.SetActive(false);
                canvasManager.spellDetailsPanel.SetActive(true);

                canvasManager.spellCardNameText.text = card.name;
                canvasManager.spellCardTypeText.text = card.currentCardType.ToString();
                canvasManager.spellCardCostText.text = card.cost.ToString();
                canvasManager.spellCardEffectText.text = card.bonusEffectText;
            }
            else
            {
                canvasManager.unitDetailsPanel.SetActive(true);
                canvasManager.spellDetailsPanel.SetActive(false);

                canvasManager.cardNameText.text = card.name;
                canvasManager.cardTypeText.text = card.currentCardType.ToString();
                canvasManager.cardAffiliationText.text = card.affiliationtext;
                canvasManager.cardATKText.text = card.ATK.ToString();
                canvasManager.cardCostText.text = card.cost.ToString();
                canvasManager.cardLoreText.text = card.loreText;
                canvasManager.cardEffectText.text = card.bonusEffectText;
            }

            //Show Card Selected in Card Details Menu
            var cardDisplay = canvasManager.cardDetailsMenu.gameObject.GetComponentInChildren<CardDisplay>();
            cardDisplay.card = card;
            cardDisplay.UpdateCard();
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
