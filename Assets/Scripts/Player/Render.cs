using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Render : MonoBehaviour
{
    void Update()
    {
        
    }
    private Transform enviroment;
    void Start()
    {
        enviroment = GameObject.FindWithTag("Enviroment Parent").transform;
    }
}
