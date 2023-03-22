using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    CharacterController controller;

    public float speed = 5;
    public LayerMask groundMask;
    public MeshRenderer playerRenderer;
    bool grounded;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        Movement();
        GroundCheck();
        Gravity();
    }


    float velocityY;
    void Gravity()
    {
        if (!grounded)
        {
            velocityY += Physics.gravity.y * Time.deltaTime;
            controller.Move(new Vector3(0, velocityY, 0) * Time.deltaTime);
        }
        else
        {
            velocityY = 0;
        }
    }
    void GroundCheck()
    {
        Ray ray = new Ray(transform.position, Vector3.down);
        RaycastHit hit;
        grounded = Physics.SphereCast(ray, 0.5f, out hit, 0.6f, groundMask.value);

        if (grounded)
        {
            playerRenderer.material.color = Color.green;
        }
        else
        {
            playerRenderer.material.color = Color.red;
        }
    }
    void Movement()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");

        Vector3 move = transform.TransformDirection(new Vector3(inputX, 0, inputY));

        if (move.magnitude > 1)
            move = move.normalized;

        controller.Move(move * Time.deltaTime * speed);
    }
    

}
