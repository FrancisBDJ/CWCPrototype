using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleHitsPlayer : MonoBehaviour
{
    
    private int _damageAmount = 10;

    public AudioClip _hitSound;
    
    private GameManager _gameManager;
    
    
    // Start is called before the first frame update
    void Start()
    {
        //_gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        _gameManager = FindObjectOfType<GameManager>();
    }

    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if(_hitSound)
                AudioSource.PlayClipAtPoint(_hitSound, transform.position);
            _gameManager.TakeDamage(_damageAmount);
            
            float lifetime = 1.5f;
            
            Destroy(gameObject, lifetime);
        }
        
        if (collision.gameObject.CompareTag("Start"))
        {
            Destroy(gameObject);
        }
    }
}
