using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuButtons : MonoBehaviour
{
    GameObject mainMenuOverlay;
    [SerializeField] GameObject settingsPanel;
    [SerializeField] GameObject instructionsPanel;
    [SerializeField] GameObject highscorePanel;
    [SerializeField] GameObject saveText;

    private void Start()
    {
        mainMenuOverlay = GameObject.FindGameObjectWithTag("Overlay");
        settingsPanel.SetActive(false);
        instructionsPanel.SetActive(false);
        highscorePanel.SetActive(false);
    }

    public void GoToSettings()
    {
        Debug.Log("settings");
        mainMenuOverlay.SetActive(false);
        settingsPanel.SetActive(true);
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Level1");
    }

    public void GoToInstructions()
    {
        Debug.Log("instructions");
        mainMenuOverlay.SetActive(false);
        instructionsPanel.SetActive(true);
    }

    public void MainMenu()
    {
        saveText.SetActive(false);
        settingsPanel.SetActive(false);
        instructionsPanel.SetActive(false);
        highscorePanel.SetActive(false);
        mainMenuOverlay.SetActive(true);
    }

    public void GoToHighScores()
    {
        Debug.Log("HighScores");
        mainMenuOverlay.SetActive(false);
        highscorePanel.SetActive(true);
    }
}
