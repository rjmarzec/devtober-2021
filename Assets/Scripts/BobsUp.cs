using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BobsUp : MonoBehaviour
{
    float startingY;
    void Start()
    {
        startingY = transform.position.y;
    }

    void Update()
    {
        transform.position = new Vector3(transform.position.x, startingY - 0.5f * Mathf.Sin(Time.time * 2f), transform.position.z);       
    }
}
