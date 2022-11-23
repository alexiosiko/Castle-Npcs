using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Librarian : Entity
{
    string[] texts = {
        "Hi there, I've never seen you here before",
        "I've seem to has misplaced my blue book of christianity ... Could you please return it to me?",
        "Ahah! You have found it! I think you greatly"
    };
    public override void Action()
    {
        base.Action ();
        if (textIndex == 1)
        {
            animator.CrossFade ("frustrated", 0.2f);
            if (Inventory.instance.RemoveItem ("bluebook") == true)
                textIndex++;
        }
        PlayAudio(sounds[0], false);
        PlayText();
        // LookTowards(player);

        StopAllCoroutines();
        StartCoroutine(Freeze());
    }
    int textIndex = 0;
    void PlayText()
    {
        CanvasManager.instance.Chat(texts[textIndex], 2);
        if (textIndex == 0)
        {
            animator.CrossFade ("talk", 0.2f);
            textIndex++;
        }
        if (textIndex == 2)
            animator.CrossFade ("excited", 0.2f);
    }
    IEnumerator Freeze(float time = 3)
    {
        // Stop walking
        wander.enabled = false;
        StopAudio (sounds[1]);

        // Wait
        yield return new WaitForSeconds (time);
        
        // Start walking
        animator.CrossFade ("walk", 0.2f);
        wander.enabled = true;
        PlayAudio (sounds[1]);
        
        // wander.LookTowardsNode(); // Change his look direction
    }
    Wander wander;
    protected override void Start()
    {
        base.Start();
        PlayAudio (sounds[1]);
        wander = GetComponent <Wander> ();
    }
}
