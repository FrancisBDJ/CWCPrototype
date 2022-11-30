using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverManager : MonoBehaviour
{
    [SerializeField] private Button _btnGoToMainMenu;
    [SerializeField] private Button _btnTryAgain;
    [SerializeField] private Button _btnQuitGame;

    private GameManager _gameManager;
   
    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    
    public void PlayLastLevel()
    {
        _gameManager.InitLevel();
        SceneManager.LoadScene("Level1");
    }
    private void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        _btnGoToMainMenu.onClick.AddListener(GoToMainMenu);
        _btnTryAgain.onClick.AddListener(PlayLastLevel);
        _btnQuitGame.onClick.AddListener(QuitGame);
    }

    void Update()
    {
        
    }
}
