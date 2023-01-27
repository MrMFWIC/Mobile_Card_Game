using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{
    [Header("Buttons")]
    public Button startButton;
    public Button settingsButton;
    public Button quitButton;
    public Button archivesButton;
    public Button creditsButton;
    public Button muteButton;
    public Button backButton;
    public Button confirmYesButton;
    public Button confirmNoButton;
    public Button confirmPassButton;
    public Button phaseSelectButton;
    public Button battlePhaseButton;
    public Button endTurnButton;
    public Button pauseButton;
    public Button resumeGame;
    public Button surrenderButton;
    public Button rematchButton;

    [Header("Sliders")]
    public Slider mainVolSlider;
    public Slider musicVolSlider;
    public Slider SFXVolSlider;

    [Header("Dropdown")]
    public Dropdown textSizeDropdown;
    public Dropdown deckResourcesDropdown;
    public Dropdown HPResourcesDropdown;
    public Dropdown roundResourcesDropdown;

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

    [Header("Text")]
    public Text quitPromptText;
    public Text toMenuPromptText;
    public Text startGameSetupText;
    public Text finishSetupText;
    public Text passP1PromptText;
    public Text passP2PromptText;
    public Text leaderPromptText;
    public Text deckPromptText;
    public Text startDuelText;
    public Text playCardText;
    public Text resumeGameText;
    public Text battlePhaseText;
    public Text attackText;
    public Text endTurnText;
    public Text surrenderText;
    public Text rematchText;

    void Start()
    {
        if (startButton)
        {
            startButton.onClick.AddListener(() => StartGame());
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

        if (muteButton)
        {
            muteButton.onClick.AddListener(() => MuteVolume());
        }

        if (backButton)
        {
            if (SceneManager.GetActiveScene().name == "Main Menu")
            {
                backButton.onClick.AddListener(() => ShowPrompt());
            }
            else if (SceneManager.GetActiveScene().name == "Arena")
            {
                if (settingsMenu.activeInHierarchy)
                {
                    backButton.onClick.AddListener(() => ShowPauseMenu());
                }
                else
                {
                    backButton.onClick.AddListener(() => OffCardDetails());
                }
            }
        }

        if (confirmYesButton)
        {
            confirmYesButton.onClick.AddListener(() => ConfirmYes());
        }

        if (confirmNoButton)
        {
            confirmNoButton.onClick.AddListener(() => ConfirmNo());
        }

        if (confirmPassButton)
        {
            confirmPassButton.onClick.AddListener(() => ConfirmPass());
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

        if (mainVolSlider)
        {
            //main volume control
        }

        if (musicVolSlider)
        {
            //music volume control
        }

        if (SFXVolSlider)
        {
            //SFX volume control
        }

        if (textSizeDropdown)
        {
            //Text size dropdown control
        }

        if (deckResourcesDropdown)
        {
            //Deck resources dropdown control
        }

        if (HPResourcesDropdown)
        {
            //HP resources dropdown control
        }

        if (roundResourcesDropdown)
        {
            //Round resources dropdown control
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

    void MuteVolume()
    {
        //Mute volume
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

    void PassPhone()
    {
        promptMenu.SetActive(true);

        if (GameManager.instance.player1Turn)
        {
            passP2PromptText.gameObject.SetActive(true);
            GameManager.instance.player1Turn = false;
        }
        else
        {
            passP1PromptText.gameObject.SetActive(true);
            GameManager.instance.player1Turn = true;
        }
    }

    void ShowPrompt()
    {
        promptMenu.SetActive(true);

        if (mainMenu.activeInHierarchy && !GameManager.instance.startGame)
        {
            quitPromptText.gameObject.SetActive(true);
        }

        if (mainMenu.activeInHierarchy && GameManager.instance.startGame)
        {
            startGameSetupText.gameObject.SetActive(true);
        }

        if (settingsMenu.activeInHierarchy || archivesMenu.activeInHierarchy)
        {
            toMenuPromptText.gameObject.SetActive(true);
        }

        if (duelSetupMenu.activeInHierarchy)
        {
            finishSetupText.gameObject.SetActive(true);
        }

        if (leaderMenu.activeInHierarchy)
        {
            leaderPromptText.gameObject.SetActive(true);
        }

        if (deckBuilderMenu.activeInHierarchy)
        {
            deckPromptText.gameObject.SetActive(true);
        }

        if (coinTossMenu)
        {
            startDuelText.gameObject.SetActive(true);
        }

        if (cardDetailsMenu.activeInHierarchy)
        {
            playCardText.gameObject.SetActive(true);
        }

        if (pauseMenu.activeInHierarchy)
        {
            resumeGameText.gameObject.SetActive(true);
        }

        if (GameManager.instance.rematch)
        {
            rematchText.gameObject.SetActive(true);
        }

        if (GameManager.instance.surrender)
        {
            surrenderText.gameObject.SetActive(true);
        }

        if (phaseSelectMenu.activeInHierarchy)
        {
            if (GameManager.instance.battlePhase && !GameManager.instance.endTurn)
            {
                battlePhaseText.gameObject.SetActive(true);
            }
            else if (GameManager.instance.endTurn)
            {
                endTurnText.gameObject.SetActive(true);
            }
        }
    }

    void ConfirmYes()
    {
        promptMenu.SetActive(false);

        quitPromptText.gameObject.SetActive(false);
        toMenuPromptText.gameObject.SetActive(false);
        passP1PromptText.gameObject.SetActive(false);
        passP2PromptText.gameObject.SetActive(false);
        startGameSetupText.gameObject.SetActive(false);
        leaderPromptText.gameObject.SetActive(false);
        deckPromptText.gameObject.SetActive(false);
        startDuelText.gameObject.SetActive(false);
        playCardText.gameObject.SetActive(false);
        battlePhaseText.gameObject.SetActive(false);
        attackText.gameObject.SetActive(false);
        endTurnText.gameObject.SetActive(false);
        surrenderText.gameObject.SetActive(false);
        rematchText.gameObject.SetActive(false);

        if (mainMenu.activeInHierarchy && GameManager.instance.quitGame)
        {
            QuitGame();
        }

        if (mainMenu.activeInHierarchy && GameManager.instance.startGame)
        {
            mainMenu.SetActive(false);
            duelSetupMenu.SetActive(true);
        }

        if (settingsMenu.activeInHierarchy && SceneManager.GetSceneByName("Main Menu").isLoaded)
        {
            settingsMenu.SetActive(false);
            mainMenu.SetActive(true);
        }

        if (archivesMenu.activeInHierarchy)
        {
            archivesMenu.SetActive(false);
            mainMenu.SetActive(true);
        }

        if (duelSetupMenu)
        {
            SceneManager.LoadScene("Game Select");
        }

        if (leaderMenu.activeInHierarchy)
        {
            if (GameManager.instance.player1Turn)
            {
                PassPhone();
            }
            else
            {
                leaderMenu.SetActive(false);
                deckBuilderMenu.SetActive(true);
            }
        }

        if (deckBuilderMenu.activeInHierarchy)
        {
            if (GameManager.instance.player1Turn)
            {
                PassPhone();
            }
            else
            {
                deckBuilderMenu.SetActive(false);
                coinTossMenu.SetActive(true);
            }
        }

        if (coinTossMenu.activeInHierarchy)
        {
            SceneManager.LoadScene("Arena");
        }

        if (cardDetailsMenu.activeInHierarchy)
        {
            //Play Card
        }

        if (pauseMenu.activeInHierarchy && !GameManager.instance.surrender)
        {
            ResumeGame();
        }

        if (GameManager.instance.rematch)
        {
            SceneManager.LoadScene("Game Select");
            leaderMenu.SetActive(false);
            coinTossMenu.SetActive(true);
            GameManager.instance.rematch = false;
        }

        if (GameManager.instance.surrender)
        {
            SceneManager.LoadScene("Game Over");
            GameManager.instance.surrender = false;
        }

        if (phaseSelectMenu.activeInHierarchy)
        {
            if (GameManager.instance.battlePhase && !GameManager.instance.endTurn)
            {
                //Begin Battle Phase
            }
            else if (GameManager.instance.endTurn)
            {
                PassPhone();
                GameManager.instance.endTurn = false;
                GameManager.instance.battlePhase = false;
            }
        }
    }

    void ConfirmNo()
    {
        promptMenu.SetActive(false);

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

        quitPromptText.gameObject.SetActive(false);
        toMenuPromptText.gameObject.SetActive(false);
        passP1PromptText.gameObject.SetActive(false);
        passP2PromptText.gameObject.SetActive(false);
        startGameSetupText.gameObject.SetActive(false);
        leaderPromptText.gameObject.SetActive(false);
        deckPromptText.gameObject.SetActive(false);
        startDuelText.gameObject.SetActive(false);
        playCardText.gameObject.SetActive(false);
        battlePhaseText.gameObject.SetActive(false);
        attackText.gameObject.SetActive(false);
        endTurnText.gameObject.SetActive(false);
        surrenderText.gameObject.SetActive(false);
        rematchText.gameObject.SetActive(false);
    }

    void ConfirmPass()
    {
        promptMenu.SetActive(false);

        quitPromptText.gameObject.SetActive(false);
        toMenuPromptText.gameObject.SetActive(false);
        passP1PromptText.gameObject.SetActive(false);
        passP2PromptText.gameObject.SetActive(false);
        startGameSetupText.gameObject.SetActive(false);
        leaderPromptText.gameObject.SetActive(false);
        deckPromptText.gameObject.SetActive(false);
        startDuelText.gameObject.SetActive(false);
        playCardText.gameObject.SetActive(false);
        battlePhaseText.gameObject.SetActive(false);
        attackText.gameObject.SetActive(false);
        endTurnText.gameObject.SetActive(false);
        surrenderText.gameObject.SetActive(false);
        rematchText.gameObject.SetActive(false);

        if (GameManager.instance.player1Turn)
        {
            //Swap to Player1
        }
        else
        {
            //Swap to Player2
        }
    }
}