using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class CanvasManager : MonoBehaviour
{
    public void Chat(string text, float time = 4)
    {
        StopCoroutine ("BeginChat"); // Stop if existing
        StartCoroutine(BeginChat(text, time));
    }
    IEnumerator BeginChat(string text, float time)
    {
        canvasChat.DOFade(0, 0); // Make alpha 0
        canvasChat.text = text;
        canvasChat.DOFade(1, 1);
        yield return new WaitForSeconds(time + 1); // The one is time for fade
        canvasChat.DOFade(0, 1);
    }
    public void OpenInterface (Transform t)
    {
        // Store interface
        currentInterface = t;

        t.DOLocalMoveY (20, 0.7f); // 20 is the height

        StatusManager.instance.Interrupt ();
    }
    Transform currentInterface;
    public void CloseInterface ()
    {
        currentInterface.DOMoveY (-500, 1);

        StatusManager.instance.UnInterrupt ();
    }
    [SerializeField] TMP_Text canvasChat;
    public static CanvasManager instance;
    void Awake ()
    {
        instance = this;
    }
}