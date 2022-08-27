using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : InteractableBehaviours, Interactable
{
    public string idRequired;
    public bool locked = false;
    public string prompt => "Press e to open door";
    public void Action()
    {
        if (locked == false) // All good
            Open();
        if (locked && inventory.Search(idRequired)) // Locked and we have the key
            Unlock();
        else // Locked and we don't have key
            WiggleDoor();
    }
    void Unlock()
    {
        locked = false;
        PlayAudio(sounds[2]); // Unlock sound effect
    }
    void WiggleDoor()
    {
            // If locked STOP
        if (locked == true)
        {
            PlayAudio(sounds[1]);
            return;
        }
    }
    void Open()
    {
        PlayAudio(sounds[0]); // 0 is door open audio
        GetComponent<Animator>().Play("Action"); // Animate
        foreach (Transform t in transform) // Swap the layerMasks
            t.gameObject.layer = LayerMask.GetMask("Default");
    }
    protected override void Start()
    {
        base.Start();
        inventory = FindObjectOfType<InventoryManager>();
    }
    InventoryManager inventory;
}
