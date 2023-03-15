using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    CharacterController controller;

    public float speed = 5;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");
        Vector3 move = new Vector3(inputX, 0, inputY);

        if (move.magnitude > 1)
            move = move.normalized;
        
        controller.Move(move * Time.deltaTime * speed);
        Debug.Log(inputX);
    }
}
