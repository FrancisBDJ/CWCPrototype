using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleHitsPlayer : MonoBehaviour
{
    
    private int _damageAmount = 10;
    
    private GameManager _gameManager;
    
    
    // Start is called before the first frame update
    void Start()
    {
        //_gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        _gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _gameManager.TakeDamage(_damageAmount);
        }
    }
}
