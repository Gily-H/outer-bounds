using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndScreenController : MonoBehaviour
{
    [SerializeField] Text scoreText;
    [SerializeField] InputField nameText;
    private string highScoreName;
    private int score;


    private void Start()
    {
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
    }


}
