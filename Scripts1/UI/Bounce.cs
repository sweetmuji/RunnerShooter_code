using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour
{
    private Rigidbody2D objectRigidbody;
    void Start()
    {
        objectRigidbody = GetComponent<Rigidbody2D>();

        objectRigidbody.linearVelocity = new Vector2(0, 5);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
