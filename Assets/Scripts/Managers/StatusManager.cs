using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class StatusManager : MonoBehaviour
{
    public GameObject crosshair;
    public bool interrupted = false;
    SoundManager soundManager;
    void Start()
    {
        soundManager = FindObjectOfType<SoundManager>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    public void Interrupt()
    {
        Debug.Log("Interrupting");
        interrupted = true;
        crosshair.SetActive(false); // Disable crosshair
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    public void UnInterrupt()
    {
        Debug.Log("not Interrupting");
        crosshair.SetActive(true); // Enable crosshair
        interrupted = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }


}
