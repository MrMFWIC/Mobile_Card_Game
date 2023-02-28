using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardDisplay : MonoBehaviour
{
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
}
