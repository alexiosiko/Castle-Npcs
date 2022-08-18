using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFlicker : MonoBehaviour
{
    new Light light;
    void Start()
    {
        InvokeRepeating("Repeat", 3, 3);
        light = GetComponent<Light>();
    }

    void Repeat()
    {
        int num = Random.Range(0, 3);

        if (num == 0)
            StartCoroutine(Flicker());

    }
    IEnumerator Flicker()
    {
        float saveIntensity = light.intensity;

        light.intensity = 0;

        yield return new WaitForSeconds(Random.value / 2);
        light.intensity = 0.5f;

        yield return new WaitForSeconds(Random.value / 2);
        light.intensity = 0;


        yield return new WaitForSeconds(Random.value / 2);
        light.intensity = saveIntensity;

    }
}
