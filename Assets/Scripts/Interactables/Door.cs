using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, Interactable
{
    public string audioName;
    public SoundManager soundManager;
    public string prompt => "Press e to open door";
    public void Start()
    {
        soundManager = FindObjectOfType<SoundManager>();
    }
    public void Action()
    {
        soundManager.PlayAudio(audioName);
        GetComponent<Animator>().Play("Action");
        foreach (Transform t in transform)
            t.gameObject.layer = LayerMask.GetMask("Default");
    }
}
