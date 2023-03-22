using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    static GameManager _instance = null;

    public static GameManager instance
    {
        get { return _instance; }
        set { _instance = value; }
    }

    //Game State variables
    [Header("Game States")]
    public bool startGame = false;
    public bool beginDuel = false;
    public bool quitGame = false;
    public bool player1Turn = true;
    public bool endTurn = false;
    public bool surrender = false;
    public bool rematch = false;
    public bool battlePhase = false;
    public bool p1StartingPlayer = true;
    public bool passingPhone = false;

    [Header("Duel Info")]
    public int healthPool = 15;
    public int roundResources = 8;
    public int deckResources = 100;

    [Header("Player 1 Info")]
    public Card p1Leader;
    public List<Card> p1Deck = new List<Card>();
    public List<Card> p1Hand = new List<Card>();
    public int p1RoundResources;

    [Header("Player 2 Info")]
    public Card p2Leader;
    public List<Card> p2Deck = new List<Card>();
    public List<Card> p2Hand = new List<Card>();
    public int p2RoundResources;
    
    void Awake()
    {
        if (instance)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void GameOver()
    {
        SceneManager.LoadScene("Game Over");
    }
}
