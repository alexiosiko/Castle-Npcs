using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MalePeasant : Entity
{
    string[] texts = {
        "I need to complete my 6000 steps before morning to keep my physique"
    };
    public override void Action ()
    {
        base.Action ();
        CanvasManager.instance.Chat (texts[0]);
        ikActive = true;

        CancelInvoke ("DisableIK");
        Invoke ("DisableIK", 3);
    }
    void DisableIK () 
    {
        ikActive = false;
    }
    void OnAnimatorIK ()
    {
        animator.SetLookAtWeight (weight);
        
        if (ikActive)
        {
            if (player != null)
            {
                animator.SetLookAtPosition (player.position);
                weight = Mathf.Lerp (weight, 1, Time.deltaTime * 2.5f);
            }
        }
        else
        {
            weight = Mathf.Lerp (weight, 0, Time.deltaTime * 2.5f);
        }
        
    }
    float weight = 0;
    [HideInInspector] public bool ikActive;
    protected override void Start ()
    {
        base.Start ();
    }

}
