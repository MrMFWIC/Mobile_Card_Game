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

    [Header("Sliders")]
    public Slider mainVolSlider;
    public Slider musicVolSlider;
    public Slider SFXVolSlider;

    [Header("Input")]
    public InputField playerNameInput;

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
            quitButton.onClick.AddListener(() => QuitGame());
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
                backButton.onClick.AddListener(() => ShowMainMenu());
            }
            else if (SceneManager.GetActiveScene().name == "Arena")
            {
                backButton.onClick.AddListener(() => OffCardDetails());
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
            resumeGame.onClick.AddListener(() => ResumeGame());
        }

        if (surrenderButton)
        {
            surrenderButton.onClick.AddListener(() => SurrenderDuel());
        }

        if (mainVolSlider)
        {

        }

        if (musicVolSlider)
        {

        }

        if (SFXVolSlider)
        {

        }

        if (playerNameInput)
        {

        }

        if (textSizeDropdown)
        {

        }

        if (deckResourcesDropdown)
        {

        }

        if (HPResourcesDropdown)
        {

        }

        if (roundResourcesDropdown)
        {

        }
    }

    void Update()
    {
        
    }

    void StartGame()
    {
        
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

    void ShowMainMenu()
    {
        settingsMenu.SetActive(false);
        mainMenu.SetActive(true);
    }

    void ShowPauseMenu()
    {
        settingsMenu.SetActive(false);
        pauseMenu.SetActive(true);
    }

    void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }

    void LoadMenu()
    {
        SceneManager.LoadScene("Title");
    }

    void ShowArchivesMenu()
    {

    }

    void LoadCredits()
    {
        SceneManager.LoadScene("Credits");
    }

    void MuteVolume()
    {

    }

    void ConfirmYes()
    {

    }

    void ConfirmNo()
    {

    }

    void ConfirmPass()
    {

    }

    void PhaseSelect()
    {

    }

    void GoToBattlePhase()
    {

    }

    void EndTurn()
    {

    }

    void PauseGame()
    {

    }

    void SurrenderDuel()
    {

    }

    void OffCardDetails()
    {

    }
}