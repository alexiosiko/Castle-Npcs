using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : Sounds
{
    public string prompt;
    public abstract void Action();
}