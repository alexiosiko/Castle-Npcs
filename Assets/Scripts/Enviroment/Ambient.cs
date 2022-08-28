using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ambient : InteractableBehaviours
{
    protected override void Start()
    {
        base.Start();
        if (sounds.Length != 0)
            PlayAudio(sounds[0]);
    }
}
