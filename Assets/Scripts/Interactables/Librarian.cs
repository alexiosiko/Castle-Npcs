using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Librarian : Entity
{
    Walk wander;
    protected override void Start()
    {
        base.Start();
        wander = GetComponent<Walk>();
    }
    public override void Action()
    {
        base.Action();
        PlayAudio(sounds[0], false);

        PlayText();

        LookTowards(player);
        
        StopAllCoroutines();
        StartCoroutine(Freeze());
    }
    void PlayText()
    {
        CanvasManager.instance.Chat("I've never seen you in this castle before ... ");
    }
    IEnumerator Freeze()
    {
        // PlayAudio(sounds[0], true);
        wander.enabled = false;
        animator.Play("idle");
        yield return new WaitForSeconds(2);
        animator.Play("walk");
        wander.enabled = true;
        wander.LookTowardsNode(); // Change his look direction
    }
}
