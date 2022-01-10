using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOutOverTime : MonoBehaviour
{
    SpriteRenderer sprite;
    public float fadeTime = 1.0f;
    public float currentAlpha = 0.0f;

    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        currentAlpha = Mathf.Max(0.0f, currentAlpha - Time.deltaTime/ fadeTime);

        sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, currentAlpha);
    }
}
