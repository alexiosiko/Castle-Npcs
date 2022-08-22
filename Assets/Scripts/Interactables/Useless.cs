using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Useless : MonoBehaviour, Interactable
{
    Animator animator;
    public string prompt => "";
    public void Action()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Useless") == false)
            animator.Play("Useless");
    }
    void Start()
    {
        animator = GetComponent<Animator>();
    }
}
