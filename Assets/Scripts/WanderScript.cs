    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class WanderScript : MonoBehaviour
{
    public float speed = 1f;
    public Vector3[] nodes;
    private float distance;
    CharacterController controller;
    private Vector3 direction;
    private int i = 0;
    private Vector3 velocity = Vector3.zero;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }
    void Wander()
    {
        // We omit the Y vector
        Vector2 startXZ = new Vector2(transform.position.x, transform.position.z);
        Vector2 endXZ = new Vector2(nodes[i].x, nodes[i].z);
        
        direction = nodes[i] - transform.position;
        direction.y = 0; // Don't care about height
        controller.Move(direction.normalized * speed * Time.deltaTime);
        

        // Get distance
        distance = Vector2.Distance(startXZ, endXZ);
        if ( distance < 0.2f )
        {
            i++;
            if (i == nodes.Length)
            i = 0;
            // Look towards new direction
            // I made this a function so i can call it from another script
            // rather than just calling this function every frame :D
            LookTowardsNode(); 
        }
    }
    public void LookTowardsNode()
    {
        transform.DOLookAt( nodes[i], 0.5f );
    }
    void Update()
    {
        Wander();

        // Gravity
        if (controller.isGrounded == false)
        {
            velocity += Physics.gravity * Time.deltaTime;
            controller.Move(velocity * Time.deltaTime);
        }        
        else
            velocity = Vector3.zero;
    }
}
