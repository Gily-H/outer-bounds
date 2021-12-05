using UnityEngine;
using UnityEngine.UI;

public class PersistScores : MonoBehaviour
{
    private const int MAX_SCORES = 5;
    private const string PLAYER_KEY = "Player";
    private const string SCORE_KEY = "Score";

    private string playerName;
    private int playerEndScore;
    
    public static PersistScores Instance;

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

    // ending screen save stats
    public void SetPlayerNameAndScore(string name, int score)
    {
        playerName = name;
        playerEndScore = score;
    }

    public void SavePlayerNameAndScore()
    {
        for (int i = 0; i < MAX_SCORES; i++)
        {
            string currentPlayer = PLAYER_KEY + i;
            string currentScore = SCORE_KEY + i;

            if (PlayerPrefs.HasKey(currentPlayer))
            {
                int storedScore = PlayerPrefs.GetInt(currentScore);

                if (playerEndScore > storedScore)
                {
                    // swap
                    string tempName = PlayerPrefs.GetString(currentPlayer);
                    int tempScore = PlayerPrefs.GetInt(currentScore);

                    PlayerPrefs.SetString(currentPlayer, playerName);
                    PlayerPrefs.SetInt(currentScore, playerEndScore);

                    playerName = tempName;
                    playerEndScore = tempScore;
                }
            }
            else
            {
                PlayerPrefs.SetString(currentPlayer, playerName);
                PlayerPrefs.SetInt(currentScore, playerEndScore);
                return;
            }
        }
    }

    public void InitializeHighscores(GameObject[] names, GameObject[] scores)
    {
        for (int i = 0; i < MAX_SCORES; i++)
        {
            string currentName = PLAYER_KEY + i;
            string currentScore = SCORE_KEY + i;

            if (PlayerPrefs.HasKey(currentName))
            {
                names[i].GetComponent<Text>().text = PlayerPrefs.GetString(currentName);
                scores[i].GetComponent<Text>().text = PlayerPrefs.GetInt(currentScore).ToString();
            }
        }
    }


}
