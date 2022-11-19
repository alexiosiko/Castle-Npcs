using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class Book : Interactable
{   
    public Sprite[] pages;
    public override void Action()
    {
        CanvasManager.instance.OpenBook(pages);
    }
    protected override void Start()
    {
        base.Start();
        prompt = "Press e to read book";
    }
}