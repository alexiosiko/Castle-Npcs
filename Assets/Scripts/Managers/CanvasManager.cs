using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class CanvasManager : MonoBehaviour
{
    StatusManager status;
    Transform bookTransform;
    public TMP_Text canvasChat;
    SoundManager soundManager;
    void Start()
    {
        status = FindObjectOfType<StatusManager>();
        bookTransform = GameObject.FindWithTag("Book Transform").transform;
        soundManager = FindObjectOfType<SoundManager>();
    }
    public void Chat(string text, float time)
    {
        StopCoroutine ("Begin"); // Stop if existing
        StartCoroutine(Begin(text, time));
    }
    public void Chat(string text)
    {
        StopCoroutine ("Begin"); // Stop if existing
        StartCoroutine(Begin(text, 2)); // Default seconds will be 2 if not specified
    }
    IEnumerator Begin(string text, float time)
    {
        canvasChat.DOFade(0, 0); // Make alpha 0
        canvasChat.text = text;
        canvasChat.DOFade(1, 1);
        yield return new WaitForSeconds(time + 1); // The one is time for fade
        canvasChat.DOFade(0, 1);
    }
    public void CloseBook()
    {
        soundManager.PlayAudio("bookclose");
        bookTransform.DOLocalMoveY(-500, 0.7f);
        status.UnInterrupt();
    }
}