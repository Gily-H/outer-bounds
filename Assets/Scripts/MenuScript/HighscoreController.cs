using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighscoreController : MonoBehaviour
{
    private GameObject[] highscoreNames;
    private GameObject[] highscores;

    private void Start()
    {
        highscoreNames = GameObject.FindGameObjectsWithTag("HSnames");
        highscores = GameObject.FindGameObjectsWithTag("HScores");

        // initialize high scores
        PersistScores.Instance.InitializeHighscores(highscoreNames, highscores);
    }
}
