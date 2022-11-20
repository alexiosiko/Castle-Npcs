    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Walk : MonoBehaviour
{
    public Vector3[] nodes;
    private int i = 0;
    void Start()
    {
        LookTowardsNode();
        GetComponent <Animator> ().Play ("walk");
    }
    void Wander()
    {
        // We omit the Y vector
        Vector2 startXZ = new Vector2(transform.position.x, transform.position.z);
        Vector2 endXZ = new Vector2(nodes[i].x, nodes[i].z);

        // Look towards
        LookTowardsNode();
        
        // Get distance
        float distance = Vector2.Distance(startXZ, endXZ);

        // When close, go to next node
        if ( distance < 0.2f )
        {
            i++;
            if (i == nodes.Length)
                i = 0;
        }
    }
    public void LookTowardsNode()
    {
        // Keep the same level of Y axis so he doesn't tilt
        // his head up or down when walking 
        nodes[i].y = transform.position.y;
        transform.DOLookAt( nodes[i], 0.5f );
    }
    void Update()
    {
        Wander();
        // // Gravity
        // if (controller.isGrounded == false)
        // {
        //     velocity += Physics.gravity * Time.deltaTime;
        //     controller.Move(velocity * Time.deltaTime);
        // }        
        // else
        //     velocity = Vector3.zero;
    }
}
