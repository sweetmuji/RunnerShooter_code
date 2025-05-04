using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Destroy : MonoBehaviour
{
    public float life = 3f;
    private float timeSum = 0f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeSum+=Time.deltaTime;

        if(timeSum>=life){
            Destroy(gameObject);
        }
    }
}
