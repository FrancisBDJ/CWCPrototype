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
    private int health;
    private int score = 0;
    private int level = 0;
    
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

    private void InitLevel()
    {
        win = false;
        _txtWinMessage.gameObject.SetActive(false);
        _btnNext.gameObject.SetActive(false);
        _btnQuit.gameObject.SetActive(false);
        health = 300;
        Time.timeScale = 1.0f;
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
        

        if (win == true)
        {
            EndLevel("You win!");
        }
    }
}
