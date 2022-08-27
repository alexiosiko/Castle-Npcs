using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public List<string> itemsIDs;
    void Start()
    {
        itemsIDs = new List<string>();
    }
    public bool Search(string id)
    {
        // Search everyobject for id
        foreach (string itemID in itemsIDs)
            if (itemID == id)
                return true;
                
        // Return false if does not exist
        return false;
    }
}
