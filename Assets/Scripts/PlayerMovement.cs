using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    CharacterController controller;

    private float speed;
    bool grounded;
    float velocityY;
    string groundTag;

    public float regularSpeed=8;
    public float speedFast=15;
    public float speedSlow=5;
    public LayerMask groundMask;
    public MeshRenderer playerRenderer;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        Movement();
        GroundCheck();
        Gravity();
        AdjustSpeedByGround();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PickUp"))
        {
            Debug.Log("detected pickup");
        }
        else
        {
            Debug.Log("detected some trigger");
        }
    }

    private void AdjustSpeedByGround()
    {
        switch (groundTag)
        {
            case "SlowGround":
                speed = speedSlow;
                break;

            case "FastGround":
                speed = speedFast;
                break;

            default:
                speed = regularSpeed;
                break;

        }
    }


    
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
            groundTag = hit.collider.tag;
        }
        else
        {
            playerRenderer.material.color = Color.red;
            groundTag = "Undefined";
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
