using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class CanvasHandler : MonoBehaviour
{
    public TMP_Text canvasChat;
    public void Alert(string text, float time)
    {
        StopCoroutine (Begin(text, 0)); // Stop if existing
        StartCoroutine(Begin(text, time));
    }
    public void Alert(string text)
    {
        StopCoroutine (Begin(text, 0)); // Stop if existing
        StartCoroutine(Begin(text, 2)); // Default seconds will be 2 if not specified
    }
    IEnumerator Begin(string text, float time)
    {
        canvasChat.DOKill(); // Kill if tween is already in

        canvasChat.DOFade(0, 0); // Make alpha 0
        canvasChat.text = text;
        canvasChat.DOFade(1, 1);
        yield return new WaitForSeconds(time + 1); // The one is time for fade
        canvasChat.DOFade(0, 1);
    }
}

