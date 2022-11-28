using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemyCar : MonoBehaviour
{
    [SerializeField] private GameObject enemyCarPrefab;
    
    private float timer = 0.0f;
    private float enemyCarSpawnFrequency = 4f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > enemyCarSpawnFrequency)
        {
            Instantiate(enemyCarPrefab, transform.position, Quaternion.identity);
            timer = 0f;
        }
    }
}
