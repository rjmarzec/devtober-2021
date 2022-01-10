using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bob : MonoBehaviour
{
    float maxAngle = 10.0f;
    float scaledTimer = 0.0f;
    public float bobSpeed = 1.0f;

    float previousX = 0.0f;

    private void Start()
    {
        previousX = transform.position.x;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow))
        {
            scaledTimer += Time.deltaTime * 10;
        }
        else
        {
            scaledTimer += Time.deltaTime;
        }

        if(transform.position.x < previousX)
        {
            transform.localScale = new Vector3(-1.0f * Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
        if (transform.position.x > previousX)
        {
            transform.localScale = new Vector3(1.0f * Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
        previousX = transform.position.x;

        transform.eulerAngles = Vector3.forward * maxAngle * Mathf.Sin(bobSpeed * scaledTimer * Mathf.PI / 2);
    }
}
