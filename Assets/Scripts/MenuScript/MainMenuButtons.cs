using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuButtons : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        // if game paused, change play button text
        if (Time.timeScale < 1.0f)
        {
            SetPlayTextToResume();
        }
    }

    public void GoToSettings()
    {
        SceneManager.LoadScene("Settings");
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Level1");
    }

    public void GoToInstructions()
    {
        SceneManager.LoadScene("Instructions");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    // when game paused and return to main menu, play button should display "resume game" instead of "play game"
    private void SetPlayTextToResume()
    {
        GameObject.Find("PlayButton").GetComponentInChildren<Text>().text = "Resume Game";
    }
}
