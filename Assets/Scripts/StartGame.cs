using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class StartGame : MonoBehaviour
{
    public int difficulty = 1;
    //public Slider slider;
    public DifficultyChoice choice;
    //public UpdateSlider update;

    // Start is called before the first frame update
    void Start()
    {
        //update = GameObject.Find("DifficultySlider").GetComponent<UpdateSlider>();
        choice = GameObject.Find("LevelDifficulty").GetComponent<DifficultyChoice>();
        //slider = GameObject.Find("DifficultySlider").GetComponent<Slider>();
        //difficulty = choice.getDifficulty();
        difficulty = PlayerPrefs.GetInt("GameDifficulty");

        if (difficulty == 1)
        {
            Debug.Log("No records");
            PlayerPrefs.SetInt("GameDifficulty", 1);
            Debug.Log($"Current Diffculty: {PlayerPrefs.GetInt("GameDifficulty")}");
        }
        else
        {
            difficulty = 2;
            PlayerPrefs.SetInt("GameDifficulty", 2);
            Debug.Log($"Current Diffculty: {PlayerPrefs.GetInt("GameDifficulty")}");
        }

        //update.updateSlider(difficulty);
    }

    // Update is called once per frame
    void Update()
    {
        //difficulty = slider.value;
    }

    public void LoadLevel()
    {
        //slider = GameObject.Find("Slider").GetComponent<Slider>();
        //difficulty = slider.value;
        choice.updateDifficulty();
        SceneManager.LoadScene("Island");
    }

    public void updateDifficulty(float difficulty)
    {
        //difficulty = slider.value;
    }

    public float getDifficulty()
    {
        return difficulty;
    }

}
