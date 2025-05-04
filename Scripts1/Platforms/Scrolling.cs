using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scrolling : MonoBehaviour
{
    public static float Speed;
    
    void Start()
    {
  
    }

    void Update()
    {
        transform.Translate(Vector2.left * Speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D collider){
        if(collider.gameObject.tag=="DiePlatform"){
            Destroy(gameObject);
        }
    }
}

