using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceableCondition : MonoBehaviour
{
    public Transform actionTransform;
    public void Check()
    {
        int correct = 0;
        for (int i = 0; i < transform.childCount; i++)
        {
            Transform child = transform.GetChild(i);

            // If placeable spot has not object in child -> empty
            if (child.childCount == 0)
                continue;

            if (child.GetComponent<PlaceableSpot>().requiredItemName == child.GetChild(0).GetComponent<Collectable>().itemName)
                correct++;
        }
        if (correct == transform.childCount) // Looks good!
            actionTransform.GetComponent<InteractableInterface>().Action();
    }

}
