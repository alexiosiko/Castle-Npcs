using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : Interactable
{
    public override void Action()
    {
        GetComponent<Animator>().Play("Open");
        
        if (sounds.Length != 0)
            PlayAudio(sounds[0]);

        foreach (Transform t in transform) // Swap the layerMasks
            t.gameObject.layer = LayerMask.GetMask("Default");
    }
    protected override void Start()
    {
        base.Start ();
        prompt = "Press e to open chest";
    }
}
