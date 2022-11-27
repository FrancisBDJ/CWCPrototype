using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverManager : MonoBehaviour
{
    [SerializeField] private Button _btnGoToMainMenu;
    [SerializeField] private Button _btnTryAgain;
    [SerializeField] private Button _btnQuitGame;
   
    private void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    
    private void PlayLastLevel()
    {
        SceneManager.LoadScene("Level1");
    }
    
    private void QuitGame()
    {
        #if UNITY_EDITOR
            EditorApplication.isPlaying = false;
        #else
            EditorApplication.Quit();
        #endif
    }

    private void Start()
    {
        
        _btnGoToMainMenu.onClick.AddListener(GoToMainMenu);
        _btnTryAgain.onClick.AddListener(PlayLastLevel);
        _btnQuitGame.onClick.AddListener(QuitGame);
    }

    void Update()
    {
        
    }
}
