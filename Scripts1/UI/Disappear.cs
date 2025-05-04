using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disappear : MonoBehaviour
{
    public float Disapp = 1.0f;
    private float timeSum = 0f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeSum+=Time.deltaTime;

        if(timeSum>=Disapp){
            gameObject.SetActive(false);
            timeSum = 0f;
        }
    }
}
