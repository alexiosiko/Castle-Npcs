using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerMovement : MonoBehaviour
{
    public float baseSpeed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;
    public float sprintSpeed = 5f;
    float speedBoost = 1f;
    Vector3 velocity;
    Vector3 move = Vector3.zero;
    void Update()
    {
        MovePlayer ();
        AnimateHand ();
    }
    void AnimateHand ()
    {
        // Animate hand walking
        if (move != Vector3.zero)
        {
            print ("moving");

            if (handAnimator.GetCurrentAnimatorStateInfo(0).IsName("Walk") == false)
                handAnimator.CrossFade ("Walk", 0.2f);
        }
        else
        {
            print ("idleing");
            if (handAnimator.GetCurrentAnimatorStateInfo(0).IsName("Idle") == false)
                handAnimator.CrossFade ("Idle", 0.2f);
        }
    }
    void MovePlayer()
    {
        // If interrupted
        if (StatusManager.instance.interrupted == true)
            return;
            
        // Don't ask me i copied this from somewhere
        if (controller.isGrounded && velocity.y < 0)
            velocity.y = -2f;

        float x = Input.GetAxisRaw ("Horizontal");
        float z = Input.GetAxisRaw ("Vertical");

        if (Input.GetButton("Fire3"))
            speedBoost = sprintSpeed;
        else
            speedBoost = 1f;


        move = transform.right * x + transform.forward * z;
        controller.Move (move * (baseSpeed + speedBoost) * Time.deltaTime);

        // Audio -> play footsteps
        if (move != Vector3.zero)
            SoundManager.instance.PlayAudio ("footsteps");
        else
            SoundManager.instance.StopAudio ("footsteps");
        
        if (Input.GetButtonDown("Jump") && controller.isGrounded)
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);

        velocity.y += gravity * Time.deltaTime;
        controller.Move (velocity * Time.deltaTime);




    }
    CharacterController controller;
    void Start ()
    {
        controller = GetComponent <CharacterController> ();
    }
    [SerializeField] Animator handAnimator;

}