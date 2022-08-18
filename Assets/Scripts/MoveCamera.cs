using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public Transform CameraPosition;
    // He says that having a camera holder makes it less buggy so OKIE
    void Update() 
    {
        transform.position = CameraPosition.position;
    }
}
