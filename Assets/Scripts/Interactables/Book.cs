using UnityEngine;

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