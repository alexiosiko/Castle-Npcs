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
        Vector2 startXZ = new Vector3(transform.position.x, transform.position.z);
        Vector2 endXZ = new Vector3(nodes[i].x, nodes[i].z);
        distance = Vector2.Distance(startXZ, endXZ);
        
        direction = nodes[i] - transform.position;
        direction.y = 0; // Don't care about height
        controller.Move(direction.normalized * speed * Time.deltaTime);
        
        // Look towrads direction

        if ( distance < 1 )
        {
            i++;
            if (i == nodes.Length)
            i = 0;
            // Look towards new direction
            transform.DOLookAt( nodes[i], 0.5f );
        }
    }
    void Update()
    {
        Wander();

        // Gravity
        // if (controller.isGrounded == false)
        // {
        //     velocity += Physics.gravity * Time.deltaTime;
        //     controller.Move(velocity * Time.deltaTime);
        // }        
        // else
        //     velocity = Vector3.zero;
    }
}
