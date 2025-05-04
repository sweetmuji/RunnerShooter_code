using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float Speed = 10f;
    public GameObject Damage;
    void Start()
    {

    }
    private void Update()
    {
        transform.Translate(Vector2.left*Speed*Time.deltaTime);
    }
    void OnTriggerEnter2D(Collider2D collider){
        if(collider.gameObject.tag=="Player"){
            Instantiate(Damage, new Vector2(transform.position.x, transform.position.y), quaternion.identity);
            PlayerController.Life--;
            Destroy(gameObject);
        }
        else if(collider.gameObject.tag=="Attack"){
            Destroy(collider.gameObject);
            Destroy(gameObject);
        }
    }
}
