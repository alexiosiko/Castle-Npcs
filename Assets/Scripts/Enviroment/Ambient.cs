using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ambient : MonoBehaviour
{
    [SerializeField] Sound sound;
    void Start()
    {
        sound.source = gameObject.AddComponent <AudioSource> ();
        sound.source.clip = sound.clip;
        sound.source.volume = sound.volume;
        sound.source.pitch = sound.pitch;
        sound.source.loop = sound.loop;

        // For distance
        sound.source.maxDistance = 10;
        sound.source.rolloffMode = AudioRolloffMode.Linear;

        sound.source.spatialBlend = sound.spacialBlend;
        


        sound.source.Play ();
    }
}
