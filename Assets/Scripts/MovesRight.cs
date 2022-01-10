using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovesRight : MonoBehaviour
{
    private void Update()
    {
        transform.position += Vector3.right * 4f * Time.deltaTime;
    }
}
