using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guard : Entity
{
    public override void Action()
    {
        base.Action();
        canvas.Alert(text);
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("angry") == false)
            animator.CrossFade("angry", 0.5f);

    }
}
