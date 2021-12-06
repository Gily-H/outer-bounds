using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistData : MonoBehaviour
{

    public static PersistData Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    // each time start game, player ship beings with 0 score, 100% health
    private void Start()
    {
        SetScore(0);
        SetPlayerHealth(100);
    }

    // persist score throughout entire game session
    public void SetScore(int score)
    {
        PlayerPrefs.SetInt("CurrentScore", score);
    }
    public int GetScore()
    {
        return PlayerPrefs.GetInt("CurrentScore");
    }

    public void SubtractScoreOnDeath()
    {
        SetScore(Instance.GetScore() - 100);
    }

    // persist player health through scene changes
    public void SetPlayerHealth(int health)
    {
        PlayerPrefs.SetInt("PlayerHealth", health);
    }

    public void SetPlayerHealthOnDeath()
    {
        SetPlayerHealth(100);
    }

    public int GetPlayerHealth()
    {
        return PlayerPrefs.GetInt("PlayerHealth");
    }
}
