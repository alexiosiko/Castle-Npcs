using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class Book : InteractableInterface
{   
    [Header("No sounds required")]
    public Sprite[] pages;
    public override void Action()
    {
        canvasManager.OpenBook(pages);
    }
    protected override void Start()
    {
        base.Start();

        soundManager = FindObjectOfType<SoundManager>();
        status = FindObjectOfType<StatusManager>();
        canvasManager = FindObjectOfType<CanvasManager>();

        prompt = "Press e to read book";
    }
    public override void Action(int child)
    {
        // An action that ALL entites reform
    }
    SoundManager soundManager;
    StatusManager status;
    CanvasManager canvasManager;
}