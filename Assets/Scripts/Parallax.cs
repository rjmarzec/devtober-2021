using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    public float speed;
    public GameObject copy;
    private bool alreadySpawnedCopy = false;

    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;

        if(!alreadySpawnedCopy && transform.position.x < 45)
        {
            Instantiate(copy, transform.position + Vector3.right * 45.0f, Quaternion.identity);
            alreadySpawnedCopy = true;
        }    

        if(transform.position.x < -50)
        {
            Destroy(gameObject);
        }
    }
}
