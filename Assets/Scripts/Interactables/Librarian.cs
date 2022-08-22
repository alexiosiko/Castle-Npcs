using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Librarian : Entity
{
    WanderScript wander;
    protected override void Start()
    {
        base.Start();
        wander = GetComponent<WanderScript>();
    }
    public override void Action()
    {
        base.Action();
        canvas.Alert(text);
        PlayAudio(sounds[0], false);


        LookTowards(player);
        StartCoroutine(Freeze());
    }
    IEnumerator Freeze()
    {
        // PlayAudio(sounds[0], true);
        wander.enabled = false;
        animator.Play("idle");
        yield return new WaitForSeconds(2);
        animator.Play("walk");
        wander.enabled = true;
        wander.LookTowardsNode(); // Chage his direction
    }
}
