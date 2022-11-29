using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitsPlayer : MonoBehaviour
{
    private int _damageAmount = 50;
    
    private GameManager _gameManager;
    
    public AudioClip _crashSound;

    public GameObject _crashEffect;
    
    void Start()
    {
        
        _gameManager = FindObjectOfType<GameManager>();
    }
    
    public void Crash()
    {
        if (_crashSound)
        { 
            AudioSource.PlayClipAtPoint(_crashSound, transform.position); 
        }

        if (_crashEffect)
        {
            Instantiate(_crashEffect, transform.position, Quaternion.identity);
        }
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
            Crash();
            
            float lifetime = 1.5f;
            Destroy(gameObject, lifetime);
        }

        if (collision.gameObject.CompareTag("Start"))
        {
            float lifetime = 0.5f;
            Destroy(gameObject, lifetime);
        }
    }
}
