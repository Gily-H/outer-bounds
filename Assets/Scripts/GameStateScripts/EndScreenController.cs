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

    private void SetName()
    {
        nameText = GameObject.Find("InputField").GetComponent<InputField>();
        highScoreName = nameText.text;
        Debug.Log(highScoreName);
    }

    public void SaveResult()
    {
        SetName();
        PersistScores.Instance.SetPlayerNameAndScore(highScoreName, score);
        PersistScores.Instance.SavePlayerNameAndScore();

        SwitchButtonsAfterSave();
    }

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
