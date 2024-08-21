using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IslandDIfficulty : MonoBehaviour
{
    public DifficultyChoice level;

    public float difficulty;
    
    void Start()
    {
        //level = GameObject.Find("LevelDifficulty").GetComponent<DifficultyChoice>();
        //difficulty = level.getDifficulty();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public float getDifficulty()
    {
        return difficulty;
    }

    public void setDifficulty(float newdifficulty)
    {
        difficulty = newdifficulty;
    }
}
