using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameDirector : MonoBehaviour
{
    public static void QuitGame()
    {
        Application.Quit();
    }

    public static void PlayLevel(string scene)
    {
        SceneManager.LoadScene(scene);
    }
}
