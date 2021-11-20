using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
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

    }

    private void PlayerSelectionScene()
    {
        // Wait for the user to press the back button and load the main menu scene when they do
        var selectionBackButton = GameObject.Find("Button_PlayerSelection_Back").GetComponent<Button>();
        selectionBackButton.onClick.AddListener(delegate { LoadSceneByNum(0); });
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
}
