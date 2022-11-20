using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class CanvasManager : MonoBehaviour
{
    public void Chat(string text, float time = 4)
    {
        StopCoroutine ("Begin"); // Stop if existing
        StartCoroutine(Begin(text, time));
    }
    IEnumerator Begin(string text, float time)
    {
        canvasChat.DOFade(0, 0); // Make alpha 0
        canvasChat.text = text;
        canvasChat.DOFade(1, 1);
        yield return new WaitForSeconds(time + 1); // The one is time for fade
        canvasChat.DOFade(0, 1);
    }
    public void OpenBook (Sprite [] pages)
    {
        bookTransform.DOLocalMoveY (20, 0.7f); // 20 is the height

        StatusManager.instance.Interrupt();

        bookInterface.bookPages = pages;
        bookInterface.Start ();

        SoundManager.instance.PlayAudio ("bookopen");
    }
    
    public void CloseBook()
    {
        bookTransform.DOMoveY( -500f, 0.7f);
        SoundManager.instance.PlayAudio("bookclose");
        StatusManager.instance.UnInterrupt();
    }
    public Transform bookTransform;
    [SerializeField] TMP_Text canvasChat;
    public static CanvasManager instance;
    BookInterface bookInterface;
    void Awake ()
    {
        bookTransform = GameObject.FindWithTag ("Book Transform").transform;
        bookInterface = bookTransform.GetComponentInChildren <BookInterface> ();
        instance = this;
    }
}