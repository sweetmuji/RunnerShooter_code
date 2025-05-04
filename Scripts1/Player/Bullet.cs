using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float Speed = 10f;
    private float timeSum = 0f;
    void Start()
    {
    }


    void Update()
    {
        transform.Translate(Vector2.right*Speed*Time.deltaTime);

        timeSum+=Time.deltaTime;
        
        if(timeSum>=2f){
            Destroy(gameObject);
        }
        
    }

    void OnTriggerEnter2D(Collider2D collider){
        if(collider.gameObject.tag=="DieBullet"){
            Destroy(gameObject);
        }
    }

}
