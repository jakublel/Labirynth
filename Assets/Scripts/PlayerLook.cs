using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    float xRotation = 0;
    void Start()
    {
        
    }

    
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        xRotation -= mouseY;

        transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
    }
}
