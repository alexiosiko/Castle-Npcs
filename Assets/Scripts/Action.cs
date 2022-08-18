using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable] public class Action
{
    public string name;
    public Transform transform;
    [SerializeField] Type type;
    enum Type {
        single,
    }
    public void DoAction()
    {
        switch (type)
        {
            case Type.single: PlayAction(); break;
            default: Debug.Log("Unknown type ..."); break;
        }
    }
    void PlayAction()
    {
        transform.GetComponent<Animator>().Play("Action");
    }
}
