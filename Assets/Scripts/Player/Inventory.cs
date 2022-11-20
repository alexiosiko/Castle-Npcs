using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] List<string> items;
    public void AddItem (string name)
    {
        items.Add (name);
    }
    public bool RemoveItem (string name)
    {
        for (int i = 0; i < items.Count; i++)
            if (items[i] == name)
            {
                items.Remove (name);
                return true;
            }
        return false;
    }
    public bool ContainsItem (string name)
    {
        for (int i = 0; i < items.Count; i++)
            if (items[i] == name)
                return true;
        return false;
    }
    public static Inventory instance;
    void Awake ()
    {
        instance = this;
    }
}
