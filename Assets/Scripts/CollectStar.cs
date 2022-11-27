using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectStar : MonoBehaviour
{
    private GameManager _gameManager;
    public float rotationSpeed = 10f;
   
    
    public AudioClip collectSound;

    public GameObject collectEffect;
    
    void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
    }
    
    public void Collect()
    {
        if(collectSound)
            AudioSource.PlayClipAtPoint(collectSound, transform.position);
        if(collectEffect)
            Instantiate(collectEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
           
            // Add points
            Collect();
            _gameManager.AddPoints();
            Destroy(gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
        transform.Rotate (Vector3.up * rotationSpeed * Time.deltaTime, Space.World);
    }
}
