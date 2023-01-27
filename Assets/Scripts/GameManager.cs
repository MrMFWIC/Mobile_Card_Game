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

    public bool startGame = false;
    public bool quitGame = false;
    public bool player1Turn = true;
    public bool endTurn = false;
    public bool surrender = false;
    public bool rematch = false;
    public bool battlePhase = false;

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
        SceneManager.LoadScene("GameOver");
    }
}
