using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndScreenController : MonoBehaviour
{
    private const int FIRST_SCENE_INDEX = 0;

    [SerializeField] Text scoreText;
    [SerializeField] InputField nameText;
    [SerializeField] GameObject saveButton;
    [SerializeField] GameObject menuButton;
    [SerializeField] GameObject savedText;

    private string highScoreName;
    private int score;

    private void Start()
    {
        menuButton = GameObject.Find("MenuButton");
        menuButton.SetActive(false);
        savedText = GameObject.Find("SavedText");
        savedText.SetActive(false);

        score = PersistData.Instance.GetScore();
        scoreText = GameObject.Find("ScoreText").GetComponent<Text>();
        scoreText.text = scoreText.text + score;
    }

    // Save the player name
    private void SetName()
    {
        nameText = GameObject.Find("InputField").GetComponent<InputField>();
        highScoreName = nameText.text;
        Debug.Log(highScoreName);
    }

    // save the player name and the player's end score
    public void SaveResult()
    {
        SetName();
        PersistScores.Instance.SetPlayerNameAndScore(highScoreName, score);
        PersistScores.Instance.SavePlayerNameAndScore();

        SwitchButtonsAfterSave();
    }

    // switch button so player can return to main menu - prevents double save entries
    private void SwitchButtonsAfterSave()
    {
        saveButton = GameObject.Find("SaveResults");
        saveButton.SetActive(false);

        savedText.SetActive(true);
        menuButton.SetActive(true);
    }

    public void StartFromBeginning()
    {
        SceneManager.LoadScene(FIRST_SCENE_INDEX);
    }

}
