using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
[RequireComponent(typeof(CharacterController))]
public class Walk : MonoBehaviour
{
    public Transform[] nodes;
    private int i = 0;
    void Start()
    {
        LookTowardsNode();
        GetComponent <Animator> ().Play ("walk");
        controller = GetComponent <CharacterController> ();
    }
    CharacterController controller;
    void Wander()
    {
        // We omit the Y vector
        Vector2 startXZ = new Vector2(transform.position.x, transform.position.z);
        Vector2 endXZ = new Vector2(nodes[i].position.x, nodes[i].position.z);

        // Look towards
        // LookTowardsNode();
        
        // Get distance
        float distance = Vector2.Distance(startXZ, endXZ);

        // print ($"{distance} from {gameObject.name}");
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
        transform.LookAt ( new Vector3(nodes[i].position.x, transform.position.y, nodes[i].position.z));
        // transform.DOLookAt( new Vector3(nodes[i].position.x, transform.position.y, nodes[i].position.z), 0.5f );
    }
    Vector3 velocity = Vector3.zero;
    void Update()
    {
        Wander();

        // Gravity
        // if (controller.isGrounded == false)
        // {
        //     velocity += Physics.gravity * Time.deltaTime;
        //     controller.Move (velocity * Time.deltaTime);
        // }        
        // else
        //     velocity = Vector3.zero;
    }
}
