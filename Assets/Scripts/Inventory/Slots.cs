using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slots : MonoBehaviour
{

    public void AddItem(Sprite sprite, Color color, string itemName)
    {
        foreach (Transform t in transform)
        {
            Image i = t.GetChild(0).GetComponent<Image>();
            if (i.sprite == null)
            {
                // Update sprite
                i.sprite = sprite;
                i.sprite.name = itemName;
                i.color = color;

                return;
            }
        }
        Debug.Log("Inventory is full ...");
    }
    public bool TakeItem(string nameOfSprite)
    {
        foreach (Transform t in transform)
        {
            Image i = t.GetChild(0).GetComponent<Image>();

            if (i.sprite == null) // If is empty
                continue;

            if (i.sprite.name == nameOfSprite)
            {
                // Take sprite
                i.sprite = null;
                i.color = Color.clear;
                return true;
            }
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