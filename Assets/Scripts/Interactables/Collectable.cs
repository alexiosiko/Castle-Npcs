using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : InteractableInterface
{
    public string itemName;
    public Sprite sprite; // This is the sprite shown in inventory
    public override void Action()
    {
        soundManager.PlayAudio("itempickup", true); // Sound effect

        // Add the sprite
        slots.AddItem(gameObject, sprite);
    }
    public override void Action(int child)
    {
        // An action that ALL entites reform
    }
    protected override void Start()
    {
        soundManager = FindObjectOfType<SoundManager>();
        slots = FindObjectOfType<Slots>();
    }
    SoundManager soundManager;
    Slots slots;
}
