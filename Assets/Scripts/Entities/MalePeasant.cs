using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MalePeasant : Entity
{
    string[] texts = {
        "I need to complete my 6000 steps before morning to keep my physique"
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
