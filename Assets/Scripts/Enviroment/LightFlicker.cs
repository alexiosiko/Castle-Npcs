using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFlicker : MonoBehaviour
{
    new Light light;
    bool increasing = false;
    float saveIntensity;
    void Start()
    {
        // Disabled this, but i will make it work better and run this back :D

        // light = GetComponent<Light>();
        // saveIntensity = light.intensity;
        // light.intensity = Random.Range(0.3f, saveIntensity);
        // InvokeRepeating("Repeat", Random.Range(0, 1), 0.1f);
    }

    void Repeat()
    {
        if (increasing == true)
            light.intensity += 0.01f;
        else
            light.intensity -= 0.01f;

        // Conditions
        if (light.intensity < 0.3f)
            increasing = true;
        if (light.intensity > saveIntensity)
            increasing = false;
        
    }
}
