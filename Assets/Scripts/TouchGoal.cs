using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchGoal : MonoBehaviour
{
    private GameManager _gameManager;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _gameManager.win = true;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
