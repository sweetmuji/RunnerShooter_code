using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldBox : MonoBehaviour
{
    public GameObject Addcoin;
    private DataManager datamanager;

    void Start()
    {
        datamanager = FindAnyObjectByType<DataManager>();
    }

    void OnTriggerEnter2D(Collider2D collider){
        if(collider.gameObject.tag=="Player"){
            Instantiate(Addcoin, new Vector2(gameObject.transform.position.x, gameObject.transform.position.y+0.5f), Quaternion.identity);
            datamanager.AddGold(3);
            Destroy(gameObject);
        }
    }
}
