using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashingLight : MonoBehaviour
{
    float currentTime = 0.0f;
    Light light;

    void Start()
    {
        light = GetComponent<Light>();
    }

    void Update()
    {
        currentTime += Time.deltaTime;
        light.enabled = currentTime % 1 > 0.5f;
    }
}
