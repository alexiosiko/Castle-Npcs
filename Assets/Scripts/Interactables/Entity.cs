using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Entity : MonoBehaviour, Interactable
{
    public Transform player;
    public string prompt => "Press e to talk to";
    public void Action()
    {
        WanderScript wander = GetComponent<WanderScript>();
        wander.enabled = false;
        transform.DOLookAt(player.position, 0.5f);
    }
}
