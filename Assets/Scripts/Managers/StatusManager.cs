using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class StatusManager : MonoBehaviour
{
    public GameObject crosshair;
    public bool interrupted = false;
    public static StatusManager instance;
    void Awake ()
    {
        instance = this;
    }
    void Start ()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    public void Interrupt ()
    {
        interrupted = true;
        crosshair.SetActive(false); // Disable crosshair
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    public void UnInterrupt()
    {
        crosshair.SetActive(true); // Enable crosshair
        interrupted = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}