using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : Interactable
{
    public override void Action()
    {
        entity.Action ();
    }
    [SerializeField] Entity entity;
}
