using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blink : MonoBehaviour
{
    public Sprite startingSprite;
    public Sprite blinkingSprite;

    void Start()
    {
        InvokeRepeating("StartBlink", 1.9f, 2.0f);
        InvokeRepeating("EndBlink", 0.0f, 2.0f);
    }

    void StartBlink()
    {
        GetComponent<SpriteRenderer>().sprite = blinkingSprite;
    }

    void EndBlink()
    {
        GetComponent<SpriteRenderer>().sprite = startingSprite;
    }

}
