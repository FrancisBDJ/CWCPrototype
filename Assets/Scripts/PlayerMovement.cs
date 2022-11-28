using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }
    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * 20);
        }
        
        /*if (Input.GetAxisRaw("Y Axis") != 0)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * 20);
        }*/
        
        if (Input.GetKey(KeyCode.S)) 
        {
            transform.Translate(Vector3.back  * Time.deltaTime * 10);
        }
        
        
        float rotationAngle = Input.GetAxis("Mouse X");
        
        transform.Rotate(0, rotationAngle, 0);
        
    }
}
