using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : InteractableBehaviours, Interactable
{
    public string id;
    public string prompt => ""; // No prompt
    public void Action()
    {
        soundManager.PlayAudio("itempickup"); // Sound effect
        inventory.itemsIDs.Add(id); // Add id to list
        Destroy(gameObject);
    }
    protected override void Start()
    {
        base.Start();
        inventory = FindObjectOfType<InventoryManager>();
        soundManager = FindObjectOfType<SoundManager>();
    }
    InventoryManager inventory;
    SoundManager soundManager;
}
