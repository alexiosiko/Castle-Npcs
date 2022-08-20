using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Status : MonoBehaviour
{
    public GameObject crosshair;
    public Transform bookTransform;
    public bool interrupted = false;
    public void Interrupt()
    {
        Debug.Log("Interrupting");
        crosshair.SetActive(false); // Disable crosshair
        interrupted = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    public void UnInterrupt()
    {
        Debug.Log("not Interrupting");
        crosshair.SetActive(false); // Enable crosshair
        interrupted = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    public void CloseBook()
    {
        // CAll these 2 before cause it feels better
        // Cursor.lockState = CursorLockMode.Locked;
        // interrupted = false;
        // Cursor.visible = false;

        Debug.Log("CloseBook");
        bookTransform.DOLocalMoveY(-500, 1);
        Invoke("UnInterrupt", 0);
    }

}
