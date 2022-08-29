using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slots : MonoBehaviour
{
    void Update()
    {
        // Get highlight input
        for (int i = 1; i <= transform.childCount; i++)
            if (Input.GetKeyDown(i.ToString()))
                Place(i - 1);
        
    }
    void Place(int child)
    {
        Transform slotObj = transform.GetChild(child).GetChild(1);
        // if (TakeItem(slotObj.name)); // Remove item from inventory

    }
    public void AddItem(GameObject collectable, Sprite sprite, string itemName)
    {
        foreach (Transform t in transform)
        {
            Image i = t.GetChild(0).GetComponent<Image>();
            if (i.sprite == null)
            {
                // Update sprite
                i.sprite = sprite;
                i.color = collectable.GetComponent<MeshRenderer>().material.color;

                // Update name to use for ID
                t.name = itemName;

                collectable.transform.SetParent(t); // Set parent to the slot
                collectable.SetActive(false); // Disable

                return;
            }
        }
        Debug.Log("Inventory is full ...");
    }
    public bool TakeItem(string nameOfSprite)
    {
        foreach (Transform t in transform)
        {

            if (t.name == "Empty") // If IS empty
                continue;

            if (t.name != nameOfSprite) // If not the correct name
                continue;

            Image i = t.GetChild(0).GetComponent<Image>();
            
            // Reset sprite
            i.sprite = null;
            i.color = Color.clear;
            
            // Update name to default "Name"
            t.name = "Empty";

            // Delete GameObject save
            Destroy(t.GetChild(1).gameObject);

            return true;
        }
        Debug.Log("Could not find: " + nameOfSprite + "  in inventory");
        return false;
    }
    void Start()
    {
        canvas = FindObjectOfType<CanvasManager>();
    }
    CanvasManager canvas;
}