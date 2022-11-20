using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Collectable : Interactable
{
    [SerializeField] string itemName;
    public override void Action()
    {
        SoundManager.instance.PlayAudio ("itempickup", true); // Sound effect
        CanvasManager.instance.Chat ($"You've picked up {itemName}");
        transform.DOMoveY (transform.position.y + 0.5f, 0.5f);
        transform.DOScale (transform.lossyScale * 1.75f, 0.5f);
        Invoke ("DestroyItem", 0.7f);
    }
    void DestroyItem ()
    {
        Inventory.instance.AddItem (itemName);
        Destroy (gameObject);
    }


}
