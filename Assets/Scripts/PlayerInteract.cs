using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerInteract : MonoBehaviour
{
    
    void Update()
    {
        if (Input.GetKeyDown("e") && status.interrupted == false)
            Interact();
        Highlight();
    }
    void Highlight()
    {
        Debug.DrawLine(cameraPosition.position, cameraPosition.position + cameraOrientation.forward);
        if (Physics.Raycast(cameraPosition.position, cameraOrientation.forward, out hit, 2f, LayerMask.GetMask("Interactable")))
        {
            Interactable i = hit.collider.GetComponentInParent<Interactable>();
            if (i != null)
                alert.text = i.prompt;
        }
        else
            alert.text = null;
    }
    void Interact()
    {
        RaycastHit hit;
        if (Physics.Raycast(cameraPosition.position, cameraOrientation.forward, out hit, 5f, LayerMask.GetMask("Interactable")))
        {
            Interactable i = hit.collider.GetComponentInParent<Interactable>();
            if (i != null)
                i.Action();
        }
    }
    public Status status;
    public Transform cameraOrientation;
    public Transform cameraPosition;
    public TMP_Text alert;
    RaycastHit hit;
}