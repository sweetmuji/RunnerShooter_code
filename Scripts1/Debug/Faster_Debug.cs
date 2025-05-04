using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Faster_Debug : MonoBehaviour
{
    private float currentSpeed;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A)){
            Scrolling.Speed++;
            Debug.Log("속도 증가:"+Scrolling.Speed);
        }

        if(Input.GetKeyDown(KeyCode.S)){
            currentSpeed=Scrolling.Speed;
            Scrolling.Speed=0f;
            Debug.Log("멈춤!!");
            Debug.Log("커런트스피드:"+currentSpeed);
        }

        if(Input.GetKeyDown(KeyCode.D)){
            Scrolling.Speed=currentSpeed;
            Debug.Log("움직임 재개");
        }
    }
}
