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

    private void Start()
    {
        SetScore(0);
        SetPlayerHealth(100);
    }

    // health and score persistant data
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
