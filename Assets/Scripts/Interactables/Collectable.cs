using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Collectable : Interactable
{
    public override void Action()
    {
        SoundManager.instance.PlayAudio ("itempickup", true); // Sound effect
        CanvasManager.instance.Chat ($"You've picked up {transform.name}");
        GetComponent <Collider> ().enabled = false; // Disable collider DUH

        
        StartCoroutine (Animate ());
    }
    IEnumerator Animate ()
    {
        // Just incase
        transform.DOKill ();


        // Move to spot
        transform.parent = infront;
        transform.DOLocalMove (Vector3.zero, 0.5f);

        // Rotate
        transform.DORotate (new Vector3(259, 259, 259), 3);

        yield return new WaitForSeconds (2);

        // Move underneath
        transform.DOLocalMove (new Vector3 (0, -1, -1), 0.3f);

        Invoke("AddToInventory", 0.3f);
    }
    void AddToInventory ()
    {
        transform.DOKill (); // Just incase :D
        Inventory.instance.AddItem (transform);
    }
    protected override void Start ()
    {
        base.Start ();
        infront = GameObject.FindWithTag("Infront").transform;
        inventoryTransform = GameObject.FindWithTag ("Inventory").transform;
    }
    Transform infront;
    Transform inventoryTransform;
}