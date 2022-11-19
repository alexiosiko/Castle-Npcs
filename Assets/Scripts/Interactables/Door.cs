using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Interactable
{
    public string keyName;
    public bool locked = false;
    public override void Action()
    {
        if (locked == false) // Is unlocked
            Open();
        else // Door is locked
        {
            if (inventory.RemoveItem (keyName) == true)
                Unlock ();
            else
                WiggleDoor();
        }
    }
    void Unlock()
    {
        CanvasManager.instance.Chat ("You unlock the door ...", 1);
        locked = false; // UNLOCK
        PlayAudio (sounds[2]); // Unlock sound effect
    }
    void WiggleDoor()
    {
        CanvasManager.instance.Chat("You don't have a key for this ... ", 1);
        animator.Play("Wiggle");
        PlayAudio(sounds[1]);
    }
    void Open()
    {
        PlayAudio(sounds[0]); // 0 is door open audio
        animator.Play("Action"); // Animate
        foreach (Transform t in transform) // Swap the layerMasks so we don't interact with this door again DUH
            t.gameObject.layer = LayerMask.GetMask("Default");
    }
    protected override void Start()
    {
        base.Start();
        animator = GetComponent<Animator>();
        inventory = FindObjectOfType <Inventory> ();
        prompt = "Press e to open door";
    }
    Inventory inventory;
    Animator animator;
}