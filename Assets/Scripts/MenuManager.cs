using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MenuManager : MonoBehaviour
{
    public Button easyButton;
    public Button regularButton;

    public GameObject difficultyText;
    private TextMeshProUGUI difficultyTextComponent;

    public GameObject easyText;
    private TextMeshProUGUI easyTextComponent;

    public GameObject regularText;
    private TextMeshProUGUI regularTextComponent;

    public Color selectedColor;
    public Color deselectedColor;

    public TextMeshProUGUI highestScoreText;

    // Start is called before the first frame update
    void Start()
    {
        difficultyTextComponent = difficultyText.GetComponent<TextMeshProUGUI>();
        easyTextComponent = easyText.GetComponent<TextMeshProUGUI>();
        regularTextComponent = regularText.GetComponent<TextMeshProUGUI>();

        GetDifficulty();
        UpdateHighestScore();

        MusicManager musicManager = MusicManager.Instance;

        musicManager.PlayMenuSong();
    }

    private void UpdateHighestScore()
    {
        int highestScore = PlayerPrefs.GetInt("HighestScore");
        highestScoreText.text = "Highest score: " + highestScore;
    }

    private void GetDifficulty()
    {
        string difficulty = PlayerPrefs.GetString("Difficulty");

        if (string.IsNullOrEmpty(difficulty))
        {
            PlayerPrefs.SetString("Difficulty", "Easy");
            easyButton.Select();
            difficultyTextComponent.text = "Easy enemies";
            SetAllColorsToSelected(easyButton, true);
            SetAllColorsToSelected(regularButton, false);
        }
        else
        {
            switch (difficulty)
            {
                case "Easy":
                    easyButton.Select();
                    difficultyTextComponent.text = "Easy enemies";
                    PlayerPrefs.SetString("Difficulty", "Easy");
                    SetAllColorsToSelected(easyButton, true);
                    SetAllColorsToSelected(regularButton, false);

                    break;
                case "Regular":
                    regularButton.Select();
                    difficultyTextComponent.text = "Easy and stronger enemies!";
                    PlayerPrefs.SetString("Difficulty", "Regular");
                    SetAllColorsToSelected(easyButton, false);
                    SetAllColorsToSelected(regularButton, true);

                    break;
            }
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void SelectDifficulty(string difficulty)
    {
        if (!string.IsNullOrEmpty(difficulty))
        {
            PlayerPrefs.SetString("Difficulty", difficulty);

            switch (difficulty)
            {
                case "Easy":
                    difficultyTextComponent.text = "Easy enemies";
                    SetAllColorsToSelected(easyButton, true);
                    SetAllColorsToSelected(regularButton, false);

                    break;
                case "Regular":
                    difficultyTextComponent.text = "Easy and stronger enemies!";
                    SetAllColorsToSelected(easyButton, false);
                    SetAllColorsToSelected(regularButton, true);

                    break;
            }
        }
    }

    private void SetAllColorsToSelected(Button button, bool isSelected)
    {
        if (isSelected)
        {
            ColorBlock regularButtonColors2 = button.colors;

            regularButtonColors2.normalColor = selectedColor;
            regularButtonColors2.pressedColor = selectedColor;
            regularButtonColors2.selectedColor = selectedColor;

            button.colors = regularButtonColors2;
        }
        else
        {
            ColorBlock regularButtonColors2 = button.colors;

            regularButtonColors2.normalColor = deselectedColor;
            regularButtonColors2.pressedColor = deselectedColor;
            regularButtonColors2.selectedColor = deselectedColor;

            button.colors = regularButtonColors2;
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}