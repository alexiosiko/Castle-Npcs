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
        ikActive = true;

        CancelInvoke ("DisableIK");
        Invoke ("DisableIK", 3);
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
    void DisableIK () 
    {
        ikActive = false;
    }
    protected override void Start()
    {
        base.Start ();
        animator.Play ("sitting");
    }
    [HideInInspector] public bool ikActive;
    float weight = 0;
}