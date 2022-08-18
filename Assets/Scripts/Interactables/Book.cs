using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class Book : MonoBehaviour, Interactable
{   
    public Status status;
    public Transform bookTransform;
    public string bookText;
    public TMP_Text text;
    public string prompt => "Press e to read book";
    public void Action()
    {
        bookTransform.DOLocalMoveY(0, 1);
        text.text = bookText;
        status.Interrupt();
    }
}
