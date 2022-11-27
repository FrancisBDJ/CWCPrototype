using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitsPlayer : MonoBehaviour
{
    private int _damageAmount = 50;
    
    private GameManager _gameManager;
    
    void Start()
    {
        
        _gameManager = FindObjectOfType<GameManager>();
    }

    private void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * 20);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _gameManager.TakeDamage(_damageAmount);
        }
    }
}
