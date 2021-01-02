using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    public GameObject cammera;
    public float parallaxEffect;
    private float length, startPos;
    void Start()
    {
        startPos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    
    void FixedUpdate()
    {
        float temp = (cammera.transform.position.x * (1 - parallaxEffect)); // back ground repeat
        float distance = (cammera.transform.position.x * parallaxEffect);

        transform.position = new Vector3(startPos + distance, transform.position.y, transform.position.z);

        if (temp > startPos + length )
        {
            startPos += length; 
        }
        else if (temp < startPos - length )
        {
            startPos -= length;
        }
    }
}
