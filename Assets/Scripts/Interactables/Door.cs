using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : InteractableBehaviours, Interactable
{
    public bool locked = false;
    public string prompt => "Press e to open door";
    public void Action()
    {
        // If locked STOP
        if (locked == true)
        {
            PlayAudio(sounds[1]);
            return;
        }

        // soundManager.PlayAudio("opendoor");
        PlayAudio(sounds[0]);

        GetComponent<Animator>().Play("Action");
        foreach (Transform t in transform)
            t.gameObject.layer = LayerMask.GetMask("Default");
    }

}
