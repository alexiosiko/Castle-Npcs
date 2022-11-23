using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class Entity : Interactable
{
    protected Animator animator;
    protected Transform player;
    public override void Action()
    {
        ikActive = true;

        CancelInvoke ("DisableIK");
        Invoke ("DisableIK", 3);
    }
    protected void LookTowards(Transform target)
    {
        transform.DOLookAt(target.position, 1f, AxisConstraint.Y);
    }
    protected IEnumerator LookAtAndBack(Vector3 target, Vector3 defaultTarget, float time)
    {
        // This one does NOT follow the target
        transform.DOLookAt(target,  1f, AxisConstraint.Y);
        yield return new WaitForSeconds(time);
        transform.DOLookAt(defaultTarget, 1f, AxisConstraint.Y);
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
    [HideInInspector] public bool ikActive;
    protected float weight = 0;
    protected override void Start()
    {
        base.Start();
        player = GameObject.FindWithTag("Player").transform;
        animator = GetComponent <Animator> ();
        prompt = "Press e to talk to";
    }
}