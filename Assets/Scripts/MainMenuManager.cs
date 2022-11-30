using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private Button _btnNewGame;
    [SerializeField] private Button _btnLoadGame;
    [SerializeField] private Button _btnOptions;
    [SerializeField] private Button _btnQuitGame;
    
    // Start is called before the first frame update
    void Start()
    {
        _btnNewGame.onClick.AddListener(LoadLevel1);
        _btnLoadGame.onClick.AddListener(LoadLastGame);
        _btnOptions.onClick.AddListener(LoadOptionsMenu);
        _btnQuitGame.onClick.AddListener(QuitGame);
        GameObject gameManager = GameObject.Find("Game Manager");
        if (gameManager != null)
        {
            Destroy(gameManager);
        }
    }
    
    private void QuitGame()
    {
        #if UNITY_EDITOR
             EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
    private void LoadLevel1()
    {
        SceneManager.LoadScene("Level1");
    }

    private void LoadLastGame()
    {
        SceneManager.LoadScene("Level");
    }

    private void LoadOptionsMenu()
    {
        SceneManager.LoadScene("OptionsMenu");
    }
}
