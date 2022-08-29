using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Useless : InteractableAudio, InteractableInterface
{
    Animator animator;
    public string prompt => "";
    Vector3 defaultRotation;
    public void Action()
    {
        if (sounds.Length != 0)
            PlayAudio(sounds[0]);

        transform.DOShakeRotation(0.3f, 30, 2, 45);
        Invoke("Reset", 0.3f); // This resets to normal defaultRotation
    }
    public void Action(int child)
    {
        // An action that ALL entites reform
    }
    void Reset()
    {
        transform.DOKill();
        transform.DOLocalRotate(defaultRotation, 0.2f);
    }
    protected override void Start()
    {
        base.Start();
        
        defaultRotation = transform.localEulerAngles;
        animator = GetComponent<Animator>();
    }
}
