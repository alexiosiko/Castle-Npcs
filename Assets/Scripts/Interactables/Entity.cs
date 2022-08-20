using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;
public class Entity : MonoBehaviour, Interactable
{
    public CanvasHandler canvas;
    public string text;
    public string prompt => "Press e to talk to";
    public Animator animator;
    public virtual void Action()
    {
    }
    public void LookTowards(Transform target)
    {
        Vector3 xAndY = new Vector3(target.position.x, 0, target.position.z);
        transform.DOLookAt(xAndY, 0.5f);
    }
}
