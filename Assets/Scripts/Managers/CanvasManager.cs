using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{
    [SerializeField] Coin coin;

    Coroutine waitCoroutine;

    [Header("Buttons")]
    public Button startButton;
    public Button beginDuelButton;
    public Button settingsButton;
    public Button quitButton;
    public Button archivesButton;
    public Button creditsButton;
    public Button settingsToMenuButton;
    public Button settingsToPauseButton;
    public Button archivesToMenuButton;
    public Button duelSetupToMenuButton;
    public Button offDetailsButton;
    public Button confirmYesButton;
    public Button confirmNoButton;
    public Button phaseSelectButton;
    public Button battlePhaseButton;
    public Button endTurnButton;
    public Button pauseButton;
    public Button resumeGame;
    public Button surrenderButton;
    public Button rematchButton;
    public Button addToDeckButton;
    public Button flipCoinButton;

    [Header("Sliders")]
    public Slider mainVolSlider;
    public Slider musicVolSlider;
    public Slider SFXVolSlider;

    [Header("Toggles")]
    public Toggle muteToggle;

    [Header("Menus")]
    public GameObject mainMenu;
    public GameObject settingsMenu;
    public GameObject archivesMenu;
    public GameObject duelSetupMenu;
    public GameObject leaderMenu;
    public GameObject deckBuilderMenu;
    public GameObject coinTossMenu;
    public GameObject promptMenu;
    public GameObject cardDetailsMenu;
    public GameObject pauseMenu;
    public GameObject phaseSelectMenu;

    [Header("Panels")]
    public GameObject unitDetailsPanel;
    public GameObject spellDetailsPanel;

    [Header("Turn Indicators")]
    public GameObject p1TurnIndicator;
    public GameObject p2TurnIndicator;

    [Header("Text")]
    public Text quitPromptText;
    public Text toMenuPromptText;
    public Text startGameSetupText;
    public Text finishSetupText;
    public Text passP1PromptText;
    public Text passP2PromptText;
    public Text leaderPromptText;
    public Text deckPromptText;
    public Text startDuelP1Text;
    public Text startDuelP2Text;
    public Text playCardText;
    public Text resumeGameText;
    public Text battlePhaseText;
    public Text attackText;
    public Text endTurnText;
    public Text surrenderText;
    public Text rematchText;
    public Text masterVolText;
    public Text musicVolText;
    public Text SFXVolText;
    public Text cardNameText;
    public Text cardTypeText;
    public Text cardAffiliationText;
    public Text cardCostText;
    public Text cardATKText;
    public Text cardLoreText;
    public Text cardEffectText;
    public Text spellCardNameText;
    public Text spellCardTypeText;
    public Text spellCardCostText;
    public Text spellCardEffectText;

    // Checks if player inputs are present.
    // Adds listeners and functionality to player inputs
    void Start()
    {
        if (startButton)
        {
            startButton.onClick.AddListener(() => StartGame());
        }

        if (beginDuelButton)
        {
            beginDuelButton.onClick.AddListener(() => BeginDuel());
        }

        if (settingsButton)
        {
            settingsButton.onClick.AddListener(() => ShowSettingsMenu());
        }

        if (quitButton)
        {
            quitButton.onClick.AddListener(() => QuitGamePrompt());
        }

        if (archivesButton)
        {
            archivesButton.onClick.AddListener(() => ShowArchivesMenu());
        }

        if (creditsButton)
        {
            creditsButton.onClick.AddListener(() => LoadCredits());
        }

        if (settingsToMenuButton)
        {
            settingsToMenuButton.onClick.AddListener(() => ShowPrompt());
        }

        if (settingsToPauseButton)
        {
            settingsToPauseButton.onClick.AddListener(() => ShowPauseMenu());
        }

        if (archivesToMenuButton)
        {
            archivesToMenuButton.onClick.AddListener(() => ShowPrompt());
        }

        if (duelSetupToMenuButton)
        {
            duelSetupToMenuButton.onClick.AddListener(() => ShowPrompt());
        }

        if (offDetailsButton)
        {
            offDetailsButton.onClick.AddListener(() => OffCardDetails());
        }

        if (confirmYesButton)
        {
            confirmYesButton.onClick.AddListener(() => ConfirmYes());
        }

        if (confirmNoButton)
        {
            confirmNoButton.onClick.AddListener(() => ConfirmNo());
        }

        if (phaseSelectButton)
        {
            phaseSelectButton.onClick.AddListener(() => PhaseSelect());
        }

        if (battlePhaseButton)
        {
            battlePhaseButton.onClick.AddListener(() => GoToBattlePhase());
        }

        if (endTurnButton)
        {
            endTurnButton.onClick.AddListener(() => EndTurn());
        }

        if (pauseButton)
        {
            pauseButton.onClick.AddListener(() => PauseGame());
        }

        if (resumeGame)
        {
            resumeGame.onClick.AddListener(() => ShowPrompt());
        }

        if (surrenderButton)
        {
            surrenderButton.onClick.AddListener(() => SurrenderDuel());
        }

        if (rematchButton)
        {
            rematchButton.onClick.AddListener(() => Rematch());
        }

        if (addToDeckButton)
        {
            addToDeckButton.onClick.AddListener(() => ShowPrompt());
        }

        if (flipCoinButton)
        {
            flipCoinButton.onClick.AddListener(() => FlipCoin());
        }

        if (mainVolSlider)
        {
            //main volume control
            mainVolSlider.onValueChanged.AddListener((value) => MasterSliderValueChange(value));
        }

        if (musicVolSlider)
        {
            //music volume control
            musicVolSlider.onValueChanged.AddListener((value) => MusicSliderValueChange(value));
        }

        if (SFXVolSlider)
        {
            //SFX volume control
            SFXVolSlider.onValueChanged.AddListener((value) => SFXSliderValueChange(value));
        }

        if (muteToggle)
        {
            muteToggle.onValueChanged.AddListener((value) => MuteVolume());
        }
    }

    void Update()
    {
        
    }

    void StartGame()
    {
        GameManager.instance.startGame = true;
        ShowPrompt();
    }

    void BeginDuel()
    {
        GameManager.instance.beginDuel = true;
        ShowPrompt();
    }

    void QuitGamePrompt()
    {
        GameManager.instance.quitGame = true;
        ShowPrompt();
    }

    void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
    }

    void ShowSettingsMenu()
    {
        if (SceneManager.GetActiveScene().name == "Main Menu")
        {
            mainMenu.SetActive(false);
            settingsMenu.SetActive(true);
        }
        else if (SceneManager.GetActiveScene().name == "Arena")
        {
            pauseMenu.SetActive(false);
            settingsMenu.SetActive(true);
        }
    }

    void ShowPauseMenu()
    {
        settingsMenu.SetActive(false);
        pauseMenu.SetActive(true);
    }

    void ResumeGame()
    {
        pauseMenu.SetActive(false);
    }

    void ShowArchivesMenu()
    {
        mainMenu.SetActive(false);
        archivesMenu.SetActive(true);
    }

    void LoadCredits()
    {
        SceneManager.LoadScene("Credits");
    }

    void AddCardToDeck()
    {
        var tempCard = cardDetailsMenu.gameObject.GetComponentInChildren<CardDisplay>();
        var counter = 0;

        if (leaderMenu.activeInHierarchy && GameManager.instance.player1Turn)
        {
            GameManager.instance.p1Leader = tempCard.card;
            GameManager.instance.p1Deck.Add(tempCard.card);
            Debug.Log($"Leader {tempCard.card.cardName} Selected For Player 1: Leader Card Added To Deck");
            PassPhone();
        }
        else if (leaderMenu.activeInHierarchy)
        {
            GameManager.instance.p2Leader = tempCard.card;
            GameManager.instance.p2Deck.Add(tempCard.card);
            Debug.Log($"Leader {tempCard.card.cardName} Selected For Player 2: Leader Card Added To Deck");
            PassPhone();
        }
        else if (GameManager.instance.player1Turn)
        {
            if (GameManager.instance.p1Deck.Contains(tempCard.card))
            {
                foreach (Card item in GameManager.instance.p1Deck)
                {
                    if (item.cardName == tempCard.card.cardName)
                    {
                        counter++;
                    }
                }
            }

            if (counter < 3)
            {
                GameManager.instance.p1Deck.Add(tempCard.card);
                Debug.Log($"Card {tempCard.card.cardName} Added To Player 1 Deck: Amount In Deck Is {counter}");
            }
            else
            {
                Debug.Log($"Card {tempCard.card.cardName} Not Added To Player 1 Deck: Amount In Deck Is {counter} - Card Limit In Deck Reached");
            }
        }
        else
        {
            if (GameManager.instance.p2Deck.Contains(tempCard.card))
            {
                foreach (Card item in GameManager.instance.p2Deck)
                {
                    if (item.cardName == tempCard.card.cardName)
                    {
                        counter++;
                    }
                }
            }

            if (counter < 3)
            {
                GameManager.instance.p2Deck.Add(tempCard.card);
                Debug.Log($"Card {tempCard.card.cardName} Added To Player 2 Deck: Amount In Deck Is {counter}");
            }
            else
            {
                Debug.Log($"Card {tempCard.card.cardName} Not Added To Player 2 Deck: Amount In Deck Is {counter} - Card Limit In Deck Reached");
            }
        }
    }

    void FlipCoin()
    {
        int turn = Random.Range(0, 2);

        if (turn == 0)
        {
            coin.Player1Flip();
            Debug.Log(GameManager.instance);
            GameManager.instance.p1StartingPlayer = true;
        }
        else if (turn == 1)
        {
            coin.Player2Flip();
            Debug.Log(GameManager.instance);
            GameManager.instance.p1StartingPlayer = false;
        }

        StartWaitCoroutine();
    }

    void MuteVolume()
    {
        //Mute volume
    }

    void MasterSliderValueChange(float value)
    {
        if (masterVolText)
        {
            masterVolText.text = (value).ToString();
            //Change Master Volume
        }
    }

    void MusicSliderValueChange(float value)
    {
        if (musicVolText)
        {
            musicVolText.text = value.ToString();
            //Change Music Volume
        }
    }

    void SFXSliderValueChange(float value)
    {
        if (SFXVolText)
        {
            SFXVolText.text = value.ToString();
            //Change SFX Volume
        }
    }

    void PhaseSelect()
    {
        phaseSelectMenu.SetActive(true);
    }

    void GoToBattlePhase()
    {
        GameManager.instance.battlePhase = true;
        ShowPrompt();
    }

    void EndTurn()
    {
        if (GameManager.instance.player1Turn)
        {
            GameManager.instance.player1Turn = false;
        }
        else
        {
            GameManager.instance.player1Turn = true;
        }

        ShowPrompt();
    }

    void PauseGame()
    {
        pauseMenu.SetActive(true);
    }

    void SurrenderDuel()
    {
        GameManager.instance.surrender = true;
        ShowPrompt();
    }

    void OffCardDetails()
    {
        cardDetailsMenu.SetActive(false);
    }

    void Rematch()
    {
        GameManager.instance.rematch = true;
        ShowPrompt();
    }

    //Sets pass-and-play prompt and sets player turn
    void PassPhone()
    {
        GameManager.instance.passingPhone = true;

        promptMenu.SetActive(true);

        if (GameManager.instance.player1Turn)
        {
            passP2PromptText.gameObject.SetActive(true);
        }
        else
        {
            passP1PromptText.gameObject.SetActive(true);
        }
    }

    //Sets text displayed on prompt
    void ShowPrompt()
    {
        promptMenu.SetActive(true);

        if (mainMenu)
        {
            if (mainMenu.activeInHierarchy && !GameManager.instance.startGame)
            {
                quitPromptText.gameObject.SetActive(true);

                return;
            }

            if (mainMenu.activeInHierarchy && GameManager.instance.startGame)
            {
                startGameSetupText.gameObject.SetActive(true);

                return;
            }
        }

        if (settingsMenu)
        {
            if (settingsMenu.activeInHierarchy || archivesMenu.activeInHierarchy)
            {
                toMenuPromptText.gameObject.SetActive(true);

                return;
            }
        }

        if (duelSetupMenu)
        {
            if (duelSetupMenu.activeInHierarchy && GameManager.instance.beginDuel)
            {
                finishSetupText.gameObject.SetActive(true);

                return;
            }

            if (duelSetupMenu.activeInHierarchy && !GameManager.instance.beginDuel)
            {
                toMenuPromptText.gameObject.SetActive(true);

                return;
            }
        }

        if (leaderMenu)
        {
            if (leaderMenu.activeInHierarchy)
            {
                leaderPromptText.gameObject.SetActive(true);

                return;
            }
        }

        if (deckBuilderMenu)
        {
            if (deckBuilderMenu.activeInHierarchy)
            {
                deckPromptText.gameObject.SetActive(true);

                return;
            }
        }

        if (coinTossMenu)
        {
            if (coinTossMenu.activeInHierarchy)
            {
                if (GameManager.instance.p1StartingPlayer)
                {
                    startDuelP1Text.gameObject.SetActive(true);
                }
                else
                {
                    startDuelP2Text.gameObject.SetActive(true);
                }
                
                return;
            }
        }

        if (cardDetailsMenu)
        {
            if (cardDetailsMenu.activeInHierarchy && SceneManager.GetSceneByName("Arena").isLoaded)
            {
                playCardText.gameObject.SetActive(true);

                return;
            }
        }

        if (pauseMenu)
        {
            if (pauseMenu.activeInHierarchy)
            {
                resumeGameText.gameObject.SetActive(true);

                return;
            }
        }

        if (GameManager.instance.rematch)
        {
            rematchText.gameObject.SetActive(true);

            return;
        }

        if (GameManager.instance.surrender)
        {
            surrenderText.gameObject.SetActive(true);

            return;
        }

        if (phaseSelectMenu)
        {
            if (phaseSelectMenu.activeInHierarchy)
            {
                if (GameManager.instance.battlePhase && !GameManager.instance.endTurn)
                {
                    battlePhaseText.gameObject.SetActive(true);

                    return;
                }
                else if (GameManager.instance.endTurn)
                {
                    endTurnText.gameObject.SetActive(true);

                    return;
                }
            }
        }
    }

    //Executes functions and game logic after confirmation of decisions
    void ConfirmYes()
    {
        promptMenu.SetActive(false);

        quitPromptText.gameObject.SetActive(false);
        toMenuPromptText.gameObject.SetActive(false);
        startGameSetupText.gameObject.SetActive(false);
        leaderPromptText.gameObject.SetActive(false);
        deckPromptText.gameObject.SetActive(false);
        startDuelP1Text.gameObject.SetActive(false);
        startDuelP2Text.gameObject.SetActive(false);
        playCardText.gameObject.SetActive(false);
        battlePhaseText.gameObject.SetActive(false);
        attackText.gameObject.SetActive(false);
        endTurnText.gameObject.SetActive(false);
        surrenderText.gameObject.SetActive(false);
        rematchText.gameObject.SetActive(false);

        if (GameManager.instance.passingPhone)
        {
            passP1PromptText.gameObject.SetActive(false);
            passP2PromptText.gameObject.SetActive(false);

            ConfirmPass();

            return;
        }

        passP1PromptText.gameObject.SetActive(false);
        passP2PromptText.gameObject.SetActive(false);

        if (mainMenu)
        {
            if (mainMenu.activeInHierarchy && GameManager.instance.quitGame)
            {
                QuitGame();

                return;
            }

            if (mainMenu.activeInHierarchy && GameManager.instance.startGame)
            {
                duelSetupMenu.SetActive(true);
                mainMenu.SetActive(false);

                return;
            }
        }

        if (settingsMenu)
        {
            if (settingsMenu.activeInHierarchy && SceneManager.GetSceneByName("Main Menu").isLoaded)
            {
                settingsMenu.SetActive(false);
                mainMenu.SetActive(true);

                return;
            }
        }

        if (archivesMenu)
        {
            if (archivesMenu.activeInHierarchy)
            {
                archivesMenu.SetActive(false);
                mainMenu.SetActive(true);

                return;
            }
        }

        if (duelSetupMenu)
        {
            if (duelSetupMenu.activeInHierarchy && GameManager.instance.beginDuel)
            {
                SceneManager.LoadScene("Game Select");

                return;
            }

            if (duelSetupMenu.activeInHierarchy && !GameManager.instance.beginDuel)
            {
                duelSetupMenu.SetActive(false);
                mainMenu.SetActive(true);

                GameManager.instance.startGame = false;

                return;
            }
        }

        if (leaderMenu)
        {
            if (leaderMenu.activeInHierarchy)
            {
                AddCardToDeck();
            }
        }

        if (deckBuilderMenu)
        {
            if (deckBuilderMenu.activeInHierarchy)
            {
                if (GameManager.instance.player1Turn)
                {
                    PassPhone();

                    return;
                }
                else
                {
                    deckBuilderMenu.SetActive(false);
                    coinTossMenu.SetActive(true);

                    return;
                }
            }
        }

        if (coinTossMenu)
        {
            if (coinTossMenu.activeInHierarchy)
            {
                SceneManager.LoadScene("Arena");

                return;
            }
        }

        if (cardDetailsMenu)
        {
            if (cardDetailsMenu.activeInHierarchy)
            {
                //Play Card

                return;
            }
        }

        if (pauseMenu)
        {
            if (pauseMenu.activeInHierarchy && !GameManager.instance.surrender)
            {
                ResumeGame();

                return;
            }
        }

        if (GameManager.instance.rematch)
        {
            SceneManager.LoadScene("Game Select");
            leaderMenu.SetActive(false);
            coinTossMenu.SetActive(true);
            GameManager.instance.rematch = false;

            return;
        }

        if (GameManager.instance.surrender)
        {
            GameManager.instance.GameOver();
            GameManager.instance.surrender = false;

            return;
        }

        if (phaseSelectMenu)
        {
            if (phaseSelectMenu.activeInHierarchy)
            {
                if (GameManager.instance.battlePhase && !GameManager.instance.endTurn)
                {
                    //Begin Battle Phase

                    return;
                }
                else if (GameManager.instance.endTurn)
                {
                    PassPhone();
                    GameManager.instance.endTurn = false;
                    GameManager.instance.battlePhase = false;

                    return;
                }
            }
        }
    }

    //Returns players to previous screen upon declination of decisions
    void ConfirmNo()
    {
        if (GameManager.instance.passingPhone)
        {
            Debug.Log("It Is Not An Option, It Is An Order");

            return;
        }

        promptMenu.SetActive(false);

        if (phaseSelectMenu)
        {
            if (phaseSelectMenu.activeInHierarchy)
            {
                if (GameManager.instance.battlePhase && !GameManager.instance.endTurn)
                {
                    GameManager.instance.battlePhase = false;
                }
                else if (GameManager.instance.endTurn)
                {
                    GameManager.instance.endTurn = false;
                }
            }
        }

        if (mainMenu)
        {
            if (mainMenu.activeInHierarchy && GameManager.instance.quitGame)
            {
                GameManager.instance.quitGame = false;
            }

            if (mainMenu.activeInHierarchy && GameManager.instance.startGame)
            {
                GameManager.instance.startGame = false;
            }
        }

        quitPromptText.gameObject.SetActive(false);
        toMenuPromptText.gameObject.SetActive(false);
        passP1PromptText.gameObject.SetActive(false);
        passP2PromptText.gameObject.SetActive(false);
        startGameSetupText.gameObject.SetActive(false);
        leaderPromptText.gameObject.SetActive(false);
        deckPromptText.gameObject.SetActive(false);
        startDuelP1Text.gameObject.SetActive(false);
        startDuelP2Text.gameObject.SetActive(false);
        playCardText.gameObject.SetActive(false);
        battlePhaseText.gameObject.SetActive(false);
        attackText.gameObject.SetActive(false);
        endTurnText.gameObject.SetActive(false);
        surrenderText.gameObject.SetActive(false);
        rematchText.gameObject.SetActive(false);
    }

    //Swap inputs and game states based on player turn
    void ConfirmPass()
    {
        if (cardDetailsMenu.activeInHierarchy)
        {
            cardDetailsMenu.SetActive(false);
        }

        promptMenu.SetActive(false);

        quitPromptText.gameObject.SetActive(false);
        toMenuPromptText.gameObject.SetActive(false);
        passP1PromptText.gameObject.SetActive(false);
        passP2PromptText.gameObject.SetActive(false);
        startGameSetupText.gameObject.SetActive(false);
        leaderPromptText.gameObject.SetActive(false);
        deckPromptText.gameObject.SetActive(false);
        startDuelP1Text.gameObject.SetActive(false);
        startDuelP2Text.gameObject.SetActive(false);
        playCardText.gameObject.SetActive(false);
        battlePhaseText.gameObject.SetActive(false);
        attackText.gameObject.SetActive(false);
        endTurnText.gameObject.SetActive(false);
        surrenderText.gameObject.SetActive(false);
        rematchText.gameObject.SetActive(false);

        if (GameManager.instance.player1Turn)
        {
            GameManager.instance.player1Turn = false;
            p1TurnIndicator.SetActive(false);
            p2TurnIndicator.SetActive(true);
        }
        else
        {
            GameManager.instance.player1Turn = true;
            p1TurnIndicator.SetActive(true);
            p2TurnIndicator.SetActive(false);
        }

        GameManager.instance.passingPhone = false;

        if (GameManager.instance.player1Turn)
        {
            if (leaderMenu.activeInHierarchy)
            {
                leaderMenu.SetActive(false);
                deckBuilderMenu.SetActive(true);
            }
            else if (deckBuilderMenu.activeInHierarchy)
            {
                deckBuilderMenu.SetActive(false);
                coinTossMenu.SetActive(true);
            }
        }
    }

    public void StartWaitCoroutine()
    {
        if (waitCoroutine == null)
        {
            waitCoroutine = StartCoroutine(WaitCoroutine());
        }
        else
        {
            StopCoroutine(waitCoroutine);
            waitCoroutine = null;
            waitCoroutine = StartCoroutine(WaitCoroutine());
        }
    }

    IEnumerator WaitCoroutine()
    {
        yield return new WaitForSeconds(5.0f);
        ShowPrompt();

        waitCoroutine = null;
    }
}