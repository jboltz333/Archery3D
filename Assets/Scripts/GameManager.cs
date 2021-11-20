using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Makes Play Game button on the main menu scene interactable/non-interactable based on if user made character selections
    private bool isInteractable = false;

    // Initially call the main menu scene function
    void Start()
    {
        MainMenuScene();
    }

    // Implements the singleton pattern
    public static GameManager Instance;
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    // OnEnable, OnDisable, and OnLevelLoaded used to call our selected scene function when the scene is loaded
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnLevelLoaded;
    }
    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnLevelLoaded;
    }
    private void OnLevelLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "PlayGameScene")
        {
            PlayGameScene();
        }
        else if (scene.name == "PlayerSelectionScene")
        {
            PlayerSelectionScene();
        }
        else if (scene.name == "InstructionsScene")
        {
            InstructionsScene();
        }
        else if (scene.name == "MainMenuScene")
        {
            MainMenuScene();
        }
        else if (scene.name == "CreditsScene")
        {
            CreditsScene();
        }
    }

    // Load a certain scenes assets
    private void LoadSceneByNum(int sceneNum)
    {
        SceneManager.LoadScene(sceneNum);
    }

    private void MainMenuScene()
    {
        var mainMenuPlayGameButton = GameObject.Find("Button_MainMenu_PlayGame").GetComponent<Button>();
        var mainMenuPlayerSelectionButton = GameObject.Find("Button_MainMenu_PlayerSelection").GetComponent<Button>();
        var mainMenuInstructionsButton = GameObject.Find("Button_MainMenu_Instructions").GetComponent<Button>();
        var mainMenuCreditsButton = GameObject.Find("Button_MainMenu_Credits").GetComponent<Button>();
        var mainMenuExitButton = GameObject.Find("Button_MainMenu_Exit").GetComponent<Button>();

        // Wait to see what button the user selects and load that buttons scene or exit if exit is pressed
        mainMenuPlayGameButton.onClick.AddListener(delegate { LoadSceneByNum(3); });
        mainMenuPlayerSelectionButton.onClick.AddListener(delegate { LoadSceneByNum(2); });
        mainMenuInstructionsButton.onClick.AddListener(delegate { LoadSceneByNum(1); });
        mainMenuCreditsButton.onClick.AddListener(delegate { LoadSceneByNum(4); });
        mainMenuExitButton.onClick.AddListener(delegate { OnExitGame(); });

        // If the user has saved his choices in the Player Selection scene, they can use the Play Game button
        mainMenuPlayGameButton.interactable = isInteractable;
    }

    private void PlayerSelectionScene()
    {
        // Wait for the user to press the back button and load the main menu scene when they do
        var selectionBackButton = GameObject.Find("Button_PlayerSelection_Back").GetComponent<Button>();
        selectionBackButton.onClick.AddListener(delegate { LoadSceneByNum(0); });

        // Wait for the user to press the Save Selections button when they are done selecting their choices
        var saveGame = GameObject.Find("Button_PlayerSelection_SaveSelections").GetComponent<Button>();
        saveGame.onClick.AddListener(delegate { OnSaveGame(); });
    }

    private void InstructionsScene()
    {
        // Wait for the user to press the back button and load the main menu scene when they do
        var instructionsBackButton = GameObject.Find("Button_Instructions_Back").GetComponent<Button>();
        instructionsBackButton.onClick.AddListener(delegate { LoadSceneByNum(0); });
    }

    private void CreditsScene()
    {
        // Wait for the user to press the back button and load the main menu scene when they do
        var creditsBackButton = GameObject.Find("Button_Credits_Back").GetComponent<Button>();
        creditsBackButton.onClick.AddListener(delegate { LoadSceneByNum(0); });
    }

    private void PlayGameScene()
    {
        // Wait for the user to press the back button and load the main menu scene when they do
        var playBackButton = GameObject.Find("Button_PlayGame_Back").GetComponent<Button>();
        playBackButton.onClick.AddListener(delegate { LoadSceneByNum(0); });
    }



    private void OnSaveGame()
    {
        // When the player's selections are saved, set this value to true so the user can press the play game button on main menu
        isInteractable = true;
    }

    // If the user clicks the Exit button, exit the game, whether the user is using the unity editor or hes playing the .exe version
    private void OnExitGame()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}
