using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;
public class Entity : InteractableInterface
{
    public string text;
    protected Animator animator;
    protected Transform player;
    
    public override void Action()
    {
        // An action that ALL entites reform
    }
    public override void Action(int child)
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
        animator = GetComponent<Animator>();
        prompt = "Press e to talk to";
    }
}