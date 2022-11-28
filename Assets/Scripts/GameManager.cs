using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public bool win = false;
    public bool paused = false;
    private int health;
    private int score = 0;
    private int level = 0;
    
    //private GameManager _gameManager;
    private PlayerMovement _playerMovement;
    
    //Cached references
    [SerializeField] private TextMeshProUGUI _txtWinMessage;
    [SerializeField] private Button _btnNext;
    [SerializeField] private Button _btnQuit;
    [SerializeField] private Slider _healthBar;
    [SerializeField] private TextMeshProUGUI _txtScore;

    public void AddPoints()
    {
        score ++;
        _txtScore.text = "Score: " + score * 100 + "pts";
    }
    


    public void TakeDamage(int damage)
    {
        health = health - damage;
        _healthBar.value = health;
        
        if (health <= 0f)
        {
            win = false;
            SceneManager.LoadScene("GameOver");
        }   
    }
    
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
       InitLevel();
       
    }

    public void InitLevel()
    {
        win = false;
        paused = false;
        _playerMovement = FindObjectOfType<PlayerMovement>();
        _txtWinMessage.gameObject.SetActive(false);
        _btnNext.gameObject.SetActive(false);
        _btnQuit.gameObject.SetActive(false);
        health = 300;
        Time.timeScale = 1.0f;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }


    private void PauseGame()
    {
        if (paused == false)
        {
            paused = true;
            Time.timeScale = 0;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            _playerMovement.enabled = false;
        }

        else
        {
            paused = false;
            Time.timeScale = 1;
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            _playerMovement.enabled = true;
        }
    }

    private void EndLevel(string message)
    {
        _txtWinMessage.gameObject.SetActive(true);
        _btnNext.gameObject.SetActive(true);
        _btnQuit.gameObject.SetActive(true);
        _txtWinMessage.text = message;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            PauseGame();
        }

        if (win == true)
        {
            EndLevel("You win!");
        }
    }
}
