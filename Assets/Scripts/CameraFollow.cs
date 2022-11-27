using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{ 
    public Transform playerTransform;

    private Vector3 offset3rdCam = new Vector3(0, 5.0f, -10.0f);
    
    
    private Vector3 offset1stCam = new Vector3(0, 1f, 2f);

    private void Start()
    {
        playerTransform = GameObject.FindWithTag("Player").transform;
    }


    // Update is called once per frame
    void Update()
    {
        if (playerTransform != null)
        {
            transform.position = playerTransform.position + offset1stCam;
            
            //transform.position = playerTransform.position + offset3rdCam;
        }
    }
}
