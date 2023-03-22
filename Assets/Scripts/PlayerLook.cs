using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    public float sensivity = 300;

    float xRotation = 0;
    Transform player;
    void Start()
    {
        player = transform.parent;
        Cursor.lockState = CursorLockMode.Locked;
    }

    
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * Time.deltaTime * sensivity;
        float mouseY = Input.GetAxis("Mouse Y") * Time.deltaTime * sensivity;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -70, 70);
        transform.localRotation = Quaternion.Euler(xRotation, 0, 0);

        player.Rotate(0, mouseX, 0);
    }
}
