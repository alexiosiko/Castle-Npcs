using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlaceableInterface : MonoBehaviour
{
    public abstract void Place(int child, Transform target);
}
