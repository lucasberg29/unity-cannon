using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{
    public string scoreTextString;

    private static int score;

    public TextMeshProUGUI scoreText;
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = scoreTextString;
    }

    public void addToScore()
    {
        ++score;
        scoreText.text = scoreTextString + " " + score;
    }

    public void ResetScore()
    {
        score = 0;
        scoreText.text = scoreTextString + " " + score;
    }

    public int GetScore()
    {
        return (int)score;
    }
}
