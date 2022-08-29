using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : InteractableAudio, Interactable
{
    public string keyName;
    public bool locked = false;
    public string prompt => "Press e to open door";
    public void Action()
    {
        if (locked == false) // Is unlocked
            Open();
        else if (slots.TakeItem(keyName)) // Check if we have key
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
        canvas.Chat("You do not have the correct key ... ", 1);
        PlayAudio(sounds[1]);
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
        slots = FindObjectOfType<Slots>();
        canvas = FindObjectOfType<CanvasManager>();
    }
    Slots slots;
    CanvasManager canvas;
}
