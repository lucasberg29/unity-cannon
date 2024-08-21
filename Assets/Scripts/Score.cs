using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private static float score;

    public Text scoreText;
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "SCORE:";
    }

    public void addToScore()
    {
        ++score;
        scoreText.text = "SCORE: " + score;
    }

    public void ResetScore()
    {
        score = 0;
        scoreText.text = "SCORE: " + score;
    }


}
