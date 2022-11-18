using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : InteractableInterface
{
    public string keyName;
    public bool locked = false;
    public override void Action()
    {
        if (locked == false) // Is unlocked
            Open();
        else // Door is locked
        {
            CanvasManager.instance.Chat("Door is locked ... ", 1);
            WiggleDoor();
        }
    }
    public override void Action(int child)
    {
        Unlock(child);
    }
    void Unlock(int child)
    {
        if (locked == false) // Is unlocked
            return;
        

        GameObject item = slots.GetItem(child);
        if (item == null) // If NO item
        {
            CanvasManager.instance.Chat("You don't have an item in this slot ...");
            WiggleDoor();
            return;
        }

        // If item is NOT the key STOP
        if (item.GetComponent<Collectable>().itemName != keyName)
        {
            CanvasManager.instance.Chat("This key does not fit ...");
            WiggleDoor();
            return;
        }

        // UNLOCK
        slots.RemoveItem(child); // Delete key
        locked = false;
        PlayAudio(sounds[2]); // Unlock sound effect
    }
    void WiggleDoor()
    {
        animator.Play("Wiggle");
        PlayAudio(sounds[1]);
    }
    void Open()
    {
        PlayAudio(sounds[0]); // 0 is door open audio
        animator.Play("Action"); // Animate
        foreach (Transform t in transform) // Swap the layerMasks
            t.gameObject.layer = LayerMask.GetMask("Default");
    }
    protected override void Start()
    {
        base.Start();
        slots = FindObjectOfType<Slots>();
        animator = GetComponent<Animator>();

        prompt = "Press e to open door";
    }

    Animator animator;
    Slots slots;
}
