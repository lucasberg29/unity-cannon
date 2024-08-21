using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DifficultyChoice : MonoBehaviour
{
    public static float difficulty = 0.5f;

    public static DifficultyChoice instance;
    public StartGame playerPrefs;

    public float currentDifficulty;

   
    // Start is called before the first frame update
    void Start()
    {
        //playerPrefs = GameObject.Find("StartGameButton").GetComponent<StartGame>();

        difficulty = playerPrefs.getDifficulty();
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            DestroyImmediate(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
    }

    public float getDifficulty()
    {
        return difficulty;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape) && SceneManager.GetActiveScene().name == "Island")
        {
            SceneManager.LoadScene("Menu");
        }

        currentDifficulty = difficulty;
    }

    public void updateDifficulty()
    {
        playerPrefs = GameObject.Find("StartGame").GetComponent<StartGame>();
        difficulty = playerPrefs.getDifficulty();
    }

}

