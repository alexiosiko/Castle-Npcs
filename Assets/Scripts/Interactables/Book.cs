using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class Book : InteractableAudio, InteractableInterface
{   
    [Header("No sounds required")]
    public Sprite[] pages;
    public string prompt => "Press e to read book";
    public void Action()
    {
        canvasManager.OpenBook(pages);
    }
    protected override void Start()
    {
        base.Start();

        soundManager = FindObjectOfType<SoundManager>();
        status = FindObjectOfType<StatusManager>();
        canvasManager = FindObjectOfType<CanvasManager>();
    }
    public void Action(int child)
    {
        // An action that ALL entites reform
    }
    SoundManager soundManager;
    StatusManager status;
    CanvasManager canvasManager;
}