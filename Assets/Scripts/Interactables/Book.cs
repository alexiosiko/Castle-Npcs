using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class Book : InteractableAudio, Interactable
{   
    SoundManager soundManager;
    StatusManager status;
    Transform bookTransform;
    TMP_Text bookTextElement;
    public Sprite[] pages;
    public string prompt => "Press e to read book";
    public void Action()
    {
        bookTransform.DOLocalMoveY(20, 0.7f); // 20 is the height
        status.Interrupt();
        BookInterface bookInterface = bookTransform.GetComponentInChildren<BookInterface>();
        bookInterface.bookPages = pages;
        bookInterface.Start();
        soundManager.PlayAudio("bookopen");

    }
    protected override void Start()
    {
        base.Start();

        soundManager = FindObjectOfType<SoundManager>();
        status = FindObjectOfType<StatusManager>();
        bookTransform = GameObject.FindWithTag("Book Transform").transform;

        // foreach (Sound s in sounds)
        //     AddSound(s);
    }
}