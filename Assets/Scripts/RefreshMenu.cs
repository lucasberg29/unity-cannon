using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RefreshMenu : MonoBehaviour
{
    public Transform tankPosition;
    public static Transform startingPosition;

    //public Score score;

    // Start is called before the first frame update
    void Start()
    {
        startingPosition = tankPosition;
        //score = GameObject.Find("Text").GetComponent<Score>();
    }

    public void refreshAll()
    {
        //score.ResetScore();
        tankPosition = startingPosition;
    }
}
