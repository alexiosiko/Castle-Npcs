using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Librarian : Entity
{
    Walk wander;
    protected override void Start()
    {
        base.Start();
        PlayAudio (sounds[1]);
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
        // Stop walking
        wander.enabled = false;
        StopAudio (sounds[1]);
        animator.Play("idle");

        // Wait
        yield return new WaitForSeconds(2);
        
        // Start walking
        animator.Play("walk");
        wander.enabled = true;
        PlayAudio (sounds[1]);
        
        wander.LookTowardsNode(); // Change his look direction
    }
}
