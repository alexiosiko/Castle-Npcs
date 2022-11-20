using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerInteract : MonoBehaviour
{
    private float reachMultiplier = 1f;
    void Update()
    {
        // Get ineteract input
        if (Input.GetKeyDown("e") && StatusManager.instance.interrupted == false
            || Input.GetMouseButtonDown(0) && StatusManager.instance.interrupted == false)
            Interact();

        // Highlight object
        Highlight();
    }
    void Highlight()
    {
        Debug.DrawLine(cameraPosition.position, cameraPosition.position + cameraPosition.forward * reachMultiplier);
        if (Physics.Raycast(cameraPosition.position, cameraPosition.forward, out hit, 2f * reachMultiplier, LayerMask.GetMask("Interactable")))
        {
            Interactable i = hit.collider.GetComponentInParent <Interactable> ();
            if (i != null)
                alert.text = i.prompt;
        }
        else
            alert.text = null;
    }
    void Interact()
    {
        RaycastHit hit;
        if (Physics.Raycast(cameraPosition.position, cameraPosition.transform.forward, out hit, 2f * reachMultiplier, LayerMask.GetMask("Interactable")))
        {
            Interactable i = hit.collider.GetComponentInParent <Interactable> ();
            if (i != null)
                i.Action();
        }
    }
    void Start()
    {
        alert = GameObject.FindWithTag("Alert").GetComponent <TMP_Text> ();
    }
    public Transform cameraPosition;
    TMP_Text alert;
    RaycastHit hit;
}