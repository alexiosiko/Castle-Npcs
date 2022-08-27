using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;
public class Entity : InteractableBehaviours, Interactable
{
    protected CanvasManager canvas;
    public string text;
    public string prompt => "Press e to talk to";
    protected Animator animator;
    protected Transform player;
    
    public virtual void Action()
    {
        // An action that ALL entites reform
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

    protected override void Start()
    {
        base.Start();
        player = GameObject.FindWithTag("Player").transform;
        canvas = FindObjectOfType<CanvasManager>();
        animator = GetComponent<Animator>();
    }
}