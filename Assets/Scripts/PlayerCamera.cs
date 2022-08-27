using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    StatusManager status;
    public float sensX;
    public float sensY;
    public Transform orientation;
    float xRotation;
    float yRotation;
    void Start()
    {
        status = FindObjectOfType<StatusManager>();
    }
    void Update()
    {   
        if (status.interrupted == true)
            return;

        float mouseX = Input.GetAxis("Mouse X") * sensX;
        float mouseY = Input.GetAxis("Mouse Y") * sensY;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        orientation.Rotate(Vector3.up * mouseX);
    }
}
