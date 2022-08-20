using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    void Start()
    {
        soundManager = FindObjectOfType<SoundManager>();
        controller = GetComponent<CharacterController>();
    }
    void Update()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        // If interrupted
        if (status.interrupted == true)
            return;
            
        // Get input
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        // Calculate movement direction
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;
        controller.Move(moveDirection.normalized * moveSpeed * Time.deltaTime);
    
        if (controller.isGrounded == false)
        {
            velocity += Physics.gravity * Time.deltaTime;
            controller.Move(velocity * Time.deltaTime);
        }        
        else
            velocity = Vector3.zero;
        if (moveDirection != Vector3.zero)
            soundManager.PlayAudio("footsteps");
        else
            soundManager.StopAudio("footsteps");
    }
    public Status status;
    [Header("Movement")]
    public float moveSpeed;
    public float groundDrag;

    // [Header("Grounded Check")]
    // public float playerHeight;
    // public LayerMask whatIsGround;
    // bool grounded;
    public Transform orientation;

    SoundManager soundManager;
    float horizontalInput;
    float verticalInput;

    public Vector3 moveDirection;
    public Vector3 velocity = Vector3.zero;
    CharacterController controller;

}
