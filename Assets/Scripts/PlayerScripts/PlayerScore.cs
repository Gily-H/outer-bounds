using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScore : MonoBehaviour
{
    private int score;
    [SerializeField] Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        scoreText = GameObject.Find("ScorePanel").GetComponent<Text>();
        DisplayScore();
    }

    private void Update()
    {
        DisplayScore();
    }

    private void DisplayScore()
    {
        scoreText.text = "Score: " + PersistData.Instance.GetScore();
    }

}
