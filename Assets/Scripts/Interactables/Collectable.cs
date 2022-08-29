using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour, InteractableInterface
{
    public string itemName;
    public Sprite sprite; // This is the sprite shown in inventory
    public string prompt => ""; // No prompt
    public void Action()
    {
        soundManager.PlayAudio("itempickup"); // Sound effect
        // Add the sprite, and the COLOR of THIS materials FIRST color
        
        slots.AddItem(gameObject, sprite);
    }
    public void Action(int child)
    {
        // An action that ALL entites reform
    }
    void Start()
    {
        soundManager = FindObjectOfType<SoundManager>();
        slots = FindObjectOfType<Slots>();
    }
    SoundManager soundManager;
    Slots slots;
}
