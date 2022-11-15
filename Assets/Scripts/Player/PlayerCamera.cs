using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] private float sensX;
    [SerializeField] private float sensY;
    [SerializeField] private Transform orientation;
    private StatusManager status;
    private float xRotation;
    private float yRotation;
    private void Start()
    {
        status = FindObjectOfType<StatusManager>();
    }
    private void Update()
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
