using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    void Start()
    {
        MainMenuScene();
    }

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

    private void LoadSceneByNum(int sceneNum)
    {
        SceneManager.LoadScene(sceneNum);
    }

    private void MainMenuScene()
    {

    }

    private void PlayerSelectionScene()
    {

    }

    private void InstructionsScene()
    {

    }

    private void CreditsScene()
    {

    }

    private void PlayGameScene()
    {

    }
}
