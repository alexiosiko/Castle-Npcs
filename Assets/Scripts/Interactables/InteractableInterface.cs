using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface InteractableInterface
{
    public string prompt { get; }
    void Action();
    void Action(int child);
}