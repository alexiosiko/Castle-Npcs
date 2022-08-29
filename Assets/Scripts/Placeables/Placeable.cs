using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Placeable : MonoBehaviour, PlaceableInterface
{
    public void Place(int child, Transform target)
    {
        // Item already exists at placeable
        if (target.childCount != 0)
            return;

        // Get item in the slot
        GameObject item = slots.GetItem(child);
        if (item == null) // If slot does NOT have an item
            return;

        // Clear inventory slot
        slots.RemoveItem(child, false); // Do NOT destory item

        // Set parameters
        item.SetActive(true); // Active
        item.transform.position = target.position; // Set position
        item.transform.SetParent(target);

        
    }
    void Start()
    {
        slots = FindObjectOfType<Slots>();
    }
    Slots slots;
}
