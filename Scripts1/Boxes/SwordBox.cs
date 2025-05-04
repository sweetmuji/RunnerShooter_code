using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordBox : MonoBehaviour
{
    public GameObject AddSword;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collider){
        if(collider.gameObject.tag=="Player"){
            Instantiate(AddSword, new Vector2(gameObject.transform.position.x, gameObject.transform.position.y+0.5f), Quaternion.identity);
            PlayerController.Bullets+=3;
            Destroy(gameObject);
        }
    }
}
