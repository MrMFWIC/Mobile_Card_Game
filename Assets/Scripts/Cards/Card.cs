using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Card")]
public class Card : ScriptableObject
{
    [Header("Card")]
    public Sprite artwork;
    public Sprite cardFrame;
    public string cardName;
    public string description;
    public int cost;
    public int ATK;
    public enum cardType
    {
        Leader,
        Unit,
        Spell
    }
    public cardType currentCardType;

    [Header("Details")]
    public string loreText;
    public string bonusEffectText;
    public string affiliationtext;
}
