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
        if (Input.GetKeyDown("e") && StatusManager.instance.interrupted == false)
            Interact();

        // Get number input
        for (int i = 1; i <= 6; i++) // 6 is the number of slots
            if (Input.GetKeyDown(i.ToString()))
            {
                UseItem(i - 1);
                PlaceItem(i - 1);
            }

        // Highlight object
        Highlight();
    }
    void PlaceItem(int child)
    {
        if (Physics.Raycast(cameraPosition.position, cameraPosition.transform.forward, out hit, 2f * reachMultiplier, LayerMask.GetMask("Placeable")))
        {
            PlaceableInterface p = hit.collider.GetComponentInParent <PlaceableInterface> ();
            if (p != null)
                p.Place(child, hit.collider.transform);
        }
    }

    void UseItem(int child)
    {
        if (Physics.Raycast(cameraPosition.position, cameraPosition.transform.forward, out hit, 2f * reachMultiplier, LayerMask.GetMask("Interactable")))
        {
            InteractableInterface i = hit.collider.GetComponentInParent <InteractableInterface> ();
            if (i != null)
                i.Action(child);
        }
    }
    void Highlight()
    {
        Debug.DrawLine(cameraPosition.position, cameraPosition.position + cameraPosition.forward * reachMultiplier);
        if (Physics.Raycast(cameraPosition.position, cameraPosition.forward, out hit, 2f * reachMultiplier, LayerMask.GetMask("Interactable")))
        {
            InteractableInterface i = hit.collider.GetComponentInParent <InteractableInterface> ();
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
            InteractableInterface i = hit.collider.GetComponentInParent <InteractableInterface> ();
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