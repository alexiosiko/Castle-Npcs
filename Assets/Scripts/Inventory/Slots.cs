using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slots : MonoBehaviour
{
    public void AddItem(GameObject collectable, Sprite sprite)
    {
        foreach (Transform t in transform)
        {
            if (t.childCount > 1)
                continue;

            Image i = t.GetChild(0).GetComponent<Image>();

            // Update sprite
            i.sprite = sprite;
            i.color = collectable.GetComponent<MeshRenderer>().material.color;

            // Add collectableGameObject to slot
            collectable.transform.SetParent(t); // Set parent to the slot
            collectable.SetActive(false); // Disable

            return;
        }
        Debug.Log("Inventory is full ...");
    }
    public void RemoveItem(int child, bool destroy = true)
    {
        // Gets the slot and calls the overloaded function with the slot transform
        Transform slot = transform.GetChild(child);
        RemoveItem(slot, destroy);
    }
    public void RemoveItem(Transform slot, bool destroy = true)
    {
        if (slot.childCount > 1)
        {
            Image i = slot.GetChild(0).GetComponent<Image>();
            i.sprite = null;
            i.color = Color.clear;

            // Destroy
            if (destroy == true)
                Destroy(slot.GetChild(1).gameObject);
        }
    }
    public GameObject GetItem(int child)
    {
        Transform slot = transform.GetChild(child);
        if (slot.childCount > 1) // Has an object
            return slot.GetChild(1).gameObject;
            
        return null; // If empty, return null
    }
}