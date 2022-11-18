using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

public class SlideManager : MonoBehaviour
{
    public static SlideManager instance;
    void Awake ()
    {
        instance = this;
    }
    public Slide[] slides;
    public Image blackOut;
    public TMP_Text text;
    void Start()
    {
        StartCoroutine(StartSlideShow());
    }
    IEnumerator StartSlideShow()
    {
        blackOut.enabled = true;
        StatusManager.instance.Interrupt();

        blackOut.DOFade(1, 1.5f);
        yield return new WaitForSeconds(1.5f);
        foreach (Slide s in slides)
        {
            text.text = s.texts;
            text.DOFade(1, 1.5f);
            yield return new WaitForSeconds(s.time + 1.5f);
            text.DOFade(0, 1.5f);
            yield return new WaitForSeconds(1.5f);
        }
        blackOut.DOFade(0, 1.5f);

        // actions[0].DoAction();
        StatusManager.instance.UnInterrupt();
    }
}
