using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private int _score;
    [SerializeField] private int _level;
    [SerializeField] private Slider _healthBar;
    [SerializeField] private TextMeshProUGUI _txtScore;

    public void AddPoints()
    {
        _score ++;
        _txtScore.text = "Score: " + _score * 100 + "pts";
    }
    


    public void TakeDamage(int damage)
    {
        
        _health = _health - damage;
        _healthBar.value = _health;
        
    }
    // Start is called before the first frame update
    void Start()
    {
        if (_level == 2)
        {
            _health = _health;
            _score = _score;
            
        }
        
        if (_level == 3)
        {
            _health = _health;
            _score = _score;
            
        }

        else
        {
            _health = 300;
            _score = 0;
            _level = 1;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_health < 0)
        {
            Time.timeScale = 0;
        }
    }
}
