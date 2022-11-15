using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : InteractableInterface
{
    public override void Action()
    {
        GetComponent<Animator>().Play("Open");
        
        if (sounds.Length != 0)
            PlayAudio(sounds[0]);

        foreach (Transform t in transform) // Swap the layerMasks
            t.gameObject.layer = LayerMask.GetMask("Default");
    }
    public override void Action(int child)
    {
        // An action that ALL entites reform
    }
    protected override void Start()
    {
        prompt = "Press e to open chest";
    }
}
