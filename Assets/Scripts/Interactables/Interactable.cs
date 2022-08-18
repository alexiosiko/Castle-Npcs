using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Interactable
{
    public string prompt { get; }
    void Action();
}