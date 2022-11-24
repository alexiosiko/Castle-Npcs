using UnityEngine;
using DG.Tweening;

public class Book : Interactable
{   
    public Sprite[] pages;
    public override void Action()
    {
        OpenBook ();
    }
    void OpenBook ()
    {
        // Set book
        bookInterface.bookPages = pages;
        bookInterface.Start ();

        // Open interface
        CanvasManager.instance.OpenInterface (bookTransform);

        // Sound
        SoundManager.instance.PlayAudio ("bookopen");
    }
    protected override void Start()
    {
        base.Start();
        prompt = "Press e to read book";
        bookTransform = GameObject.FindWithTag ("Book Transform").transform;
        bookInterface = bookTransform.GetComponentInChildren <BookInterface> ();
    }
    BookInterface bookInterface;
    Transform bookTransform;
}