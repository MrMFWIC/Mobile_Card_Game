using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CardDisplay : MonoBehaviour
{
    CanvasManager cm;

    public Card card;

    public Text nameText;
    public Text descriptionText;
    public Text costText;
    public Text ATKText;

    public Image artworkImage;
    public Image cardFrameImage;

    public Image ATKPlaceholderImage;

    void Start()
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

    private void OnMouseDown()
    {
        if (!cm.cardDetailsMenu.activeInHierarchy)
        {
            cm.cardDetailsMenu.SetActive(true);
            
            if (card.currentCardType == Card.cardType.Spell)
            {
                cm.unitDetailsPanel.SetActive(false);
                cm.spellDetailsPanel.SetActive(true);
            }
            else
            {
                cm.unitDetailsPanel.SetActive(true);
                cm.spellDetailsPanel.SetActive(false);
            }

            cm.cardNameText.text = card.name;
            cm.cardTypeText.text = card.currentCardType.ToString();
            cm.cardAffiliationText.text = card.affiliationtext;
            cm.cardATKText.text = card.ATK.ToString();
            cm.cardCostText.text = card.cost.ToString();
            cm.cardLoreText.text = card.loreText;
            cm.cardEffectText.text = card.bonusEffectText;
        }

        if (cm.cardDetailsMenu.activeInHierarchy && SceneManager.GetSceneByName("Arena").isLoaded)
        {
            //Play Card
        }
    }
}
