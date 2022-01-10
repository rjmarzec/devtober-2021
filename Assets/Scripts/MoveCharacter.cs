using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCharacter : MonoBehaviour
{
    public float speed = 10.0f;

    void Update()
    {
        if(Input.GetKey(KeyCode.UpArrow))
        {
            transform.position += speed * Vector3.forward * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.position += speed * Vector3.back * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += speed * Vector3.left * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += speed * Vector3.right * Time.deltaTime;
        }
    }
}
