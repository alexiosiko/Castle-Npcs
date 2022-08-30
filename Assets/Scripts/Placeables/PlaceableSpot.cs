using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceableSpot : MonoBehaviour, PlaceableInterface
{
    public string requiredItemName;
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
        item.transform.SetParent(target); // Set parent
        item.transform.localPosition = Vector3.zero; // Zero out the position relative to parent

        // Play audio
        soundManager.PlayAudio("itemplace", true);

        // Check conditions
        placeableCondition.Check();
    }
    void Start()
    {
        slots = FindObjectOfType<Slots>();
        soundManager = FindObjectOfType<SoundManager>();
        placeableCondition = GetComponentInParent<PlaceableCondition>();
    }
    Slots slots;
    SoundManager soundManager;
    PlaceableCondition placeableCondition;
}
