using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Inventory : MonoBehaviour
{
    public void AddItem (Transform item)
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Transform t = transform.GetChild(i);
            if (t.childCount == 0)
            {
                item.parent = t;
                return;
            }
        }
    }
    public bool RemoveItem (string name)
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Transform t = transform.GetChild (i);
            if (t.childCount != 0)
            {
                Transform item = t.GetChild (0);
                if (item.name == name)
                {
                    item.parent = null; // Removed from inventory
                    StartCoroutine (AnimateRemoval (item));
                    return true;  
                }
            }
        }
        return false;
    }
    IEnumerator AnimateRemoval (Transform item)
    {
        // Change parent
        item.parent = infront;

        // Just incase
        item.transform.DOKill ();

        // Move
        item.transform.DOLocalMove (Vector3.forward, 0.5f);

        // Rotate
        item.transform.DORotate (new Vector3(259, 259, 259), 3);

        // Wait
        yield return new WaitForSeconds (1);

        // Move above
        item.transform.DOLocalMove (item.position + new Vector3 (0, 5, 0), 0.5f);
        
        // Wait to tween before destroying
        yield return new WaitForSeconds (1f);
        Destroy (item.gameObject);
    }
    
    [HideInInspector] public static Inventory instance;
    void Awake ()
    {
        instance = this;
        infront = GameObject.FindWithTag("Infront").transform;
    }
    Transform infront;
}
