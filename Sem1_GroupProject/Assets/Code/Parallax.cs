using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    private float speed = 4f;
    private Vector3 startpos;
    void Start()
    {
        startpos = transform.position;
        
    }

    void FixedUpdate()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
        if (transform.position.x < -18.44f)
        {
            transform.position = startpos;
        }



    }
}
