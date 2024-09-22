using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{
    public string scoreTextString;

    private static int score;

    private int currentHighestScore;

    public TextMeshProUGUI scoreText;
    // Start is called before the first frame update
    void Start()
    {
        currentHighestScore = PlayerPrefs.GetInt("HighestScore");
        scoreText.text = scoreTextString;
    }

    public void addToScore()
    {
        ++score;
        scoreText.text = scoreTextString + " " + score;

        if (score > currentHighestScore)
        {
            currentHighestScore = score;
            SaveScore();
        }
    }

    public void AddToScore(int points)
    {
        score += points;
        scoreText.text = scoreTextString + " " + score;

        if (score > currentHighestScore)
        {
            currentHighestScore = score;
            SaveScore();
        }
    }

    public void ResetScore()
    {
        score = 0;
        scoreText.text = scoreTextString + " " + score;
    }

    public int GetScore()
    {
        return score;
    }

    public void SaveScore()
    {
        PlayerPrefs.SetInt("HighestScore", score);
    }
}
