using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstantlySpins : MonoBehaviour
{
    private void Update()
    {
        transform.eulerAngles = new Vector3(0, 0, (Time.time*50) % 360);
    }
}
