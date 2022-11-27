using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private bool win = false;
    private int health;
    private int score = 0;
    private int level = 0;
    
    //Cached references
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
        health = 300;
        Time.timeScale = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (health < 0)
        {
            Time.timeScale = 0;
        }
    }
}
