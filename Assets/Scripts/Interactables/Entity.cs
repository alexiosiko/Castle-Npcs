using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;
public class Entity : MonoBehaviour, Interactable
{
    public CanvasHandler canvas;
    public string prompt => "Press e to talk to";
    public Animator animator;
    public void Action()
    {
        canvas.Alert("What the fuck are you doing");
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("angry") == false) // If not angry
            animator.CrossFade("angry", 0.2f);
    }
}
