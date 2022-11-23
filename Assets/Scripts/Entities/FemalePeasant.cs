using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FemalePeasant : Entity
{
    string[] texts = {
        "Psst, hey ... If you get me out of here, I'll give you money and let you visit my farm anytime you want",
    };
    int textIndex = 0;
    public override void Action ()
    {
        base.Action ();
        CanvasManager.instance.Chat (texts[0]);
    }
    protected override void Start()
    {
        base.Start ();
        animator.Play ("sitting");
    }
}