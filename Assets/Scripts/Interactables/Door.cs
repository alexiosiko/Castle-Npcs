using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, Interactable
{
    public string prompt => "Press e to open door";
    public void Action()
    {
        GetComponent<Animator>().Play("Action");
        foreach (Transform t in transform)
            t.gameObject.layer = LayerMask.GetMask("Default");
    }
}
