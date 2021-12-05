using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyController : MonoBehaviour
{
    private const int EASY = 0;
    private const int MEDIUM = 1;
    private const int HARD = 2;

    Button easyButton;
    Button mediumButton;
    Button hardButton;

    public void Start()
    {
        easyButton = GameObject.Find("EasyButton").GetComponent<Button>();
        mediumButton = GameObject.Find("MediumButton").GetComponent<Button>();
        hardButton = GameObject.Find("HardButton").GetComponent<Button>();
        HighlightSelected();
    }

    public void setDifficultyEasy()
    {
        SetDifficulty(EASY);
        HighlightSelected();
    }

    public void setDifficultyMedium()
    {
        SetDifficulty(MEDIUM);
        HighlightSelected();
    }

    public void setDifficultyHard()
    {
        SetDifficulty(HARD);
        HighlightSelected();
    }

    private void SetDifficulty(int difficulty)
    {
        PlayerPrefs.SetInt("Difficulty", difficulty);
    }
    
    private void HighlightSelected()
    {
        ClearHighlighted();

        int difficultyValue = PlayerPrefs.GetInt("Difficulty");
        Color32 selectPurpleColor = new Color32(97, 46, 103, 255);

        if (difficultyValue == 0)
        {
            easyButton.GetComponent<Image>().color = selectPurpleColor;
        }
        else if (difficultyValue == 1)
        {
            mediumButton.GetComponent<Image>().color = selectPurpleColor;
            
        }
        else if (difficultyValue == 2)
        {
            hardButton.GetComponent<Image>().color = selectPurpleColor;

        }
    }

    private void ClearHighlighted()
    {
        Color buttonDefault = Color.white;
        easyButton.GetComponent<Image>().color = buttonDefault;
        mediumButton.GetComponent<Image>().color = buttonDefault;
        hardButton.GetComponent<Image>().color = buttonDefault;
    }
}
