using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovesDown : MonoBehaviour
{
    private void Start()
    {
        if(GetComponent<BobsUp>() != null)
        {
            Destroy(gameObject.GetComponent<BobsUp>());
        }
    }

    private void Update()
    {
        transform.position += Vector3.down * 4f * Time.deltaTime;
    }
}
