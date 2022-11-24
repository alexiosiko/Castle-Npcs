using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class KeyCode : Interactable
{
    public override void Action()
    {
        OpenKeyCode ();
    }
    void OpenKeyCode ()
    {
        keyCodeTransform.DOLocalMoveY (20, 0.7f); // 20 is the height

        CanvasManager.instance.OpenInterface (keyCodeTransform);
        SoundManager.instance.PlayAudio ("bookopen");
    }
    protected override void Start ()
    {
        base.Start ();

        keyCodeTransform = GameObject.FindWithTag ("KeyCode").transform;
    }
    TMP_Text display;
    Transform keyCodeTransform;
}
