using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class IslandManager : MonoBehaviour
{
    public IslandControls islandControls;
    public GameObject menuGameObject;

    private void Awake()
    {
        islandControls = new IslandControls();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    private void Update()
    {

    }

    //void OnEnable()
    //{
    //    islandControls.Player.Enable();
    //    islandControls.Player.PauseGame.performed += OnPauseGame;
    //}

    //void OnDisable()
    //{
    //    islandControls.Player.PauseGame.performed -= OnPauseGame;
    //    islandControls.Player.Disable();
    //}

    private void OnPauseGame(InputAction.CallbackContext context)
    {
        PauseGame();
    }

    public void PauseGame()
    {
        menuGameObject.SetActive(true);
        Time.timeScale = 0.0f;
    }

    public void ResumeGame()
    {
        menuGameObject.SetActive(false);
        Time.timeScale = 1.0f;
    }

    public void RestartLevel()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(1);
    }

    public void ReturnToMenu()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(0);
    }
}
