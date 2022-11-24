using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KeyCodeLogic : MonoBehaviour
{
    public string code = "123456";
    public void ClickButton (int num)
    {
        // Play sounds
        SoundManager.instance.PlayAudio ("keycodeclick", true);

        display.text += num;
        if (display.text == "123456")
        {
            display.color = Color.green;
            Invoke ("Unlock", 1f);
        }
    }
    void Unlock ()
    {
        CanvasManager.instance.CloseInterface ();

        // Destorying keyCodeScript disables the keycode
        // This works becuase when we intereact with door, we will Action ()
        // the door script rather than this script becuase originally the keyCodeScript (this)
        // is what is triggered
        SoundManager.instance.PlayAudio ("keycodeunlock");
        Destroy (keyCodeScript);
    }   
    public void Clear ()
    {
        display.text = null;
    }
    void Start ()
    {
        display = GameObject.Find ("Display").GetComponentInChildren <TMP_Text> ();
    }
    TMP_Text display;
    public KeyCode keyCodeScript;
}