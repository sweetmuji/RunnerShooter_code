using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy3 : MonoBehaviour
{
    public GameObject AddSword;
    public GameObject Damage_1;
    private Animator EnemyAnimator;
    private BoxCollider2D EnemyCollider;
    private bool isDead = false;
    
    void Start()
    {
        EnemyAnimator = GetComponent<Animator>();
        EnemyCollider = GetComponent<BoxCollider2D>();
    }
    void OnTriggerEnter2D(Collider2D collider){

        if(collider.gameObject.tag=="Attack"){
            Instantiate(AddSword, new Vector2(gameObject.transform.position.x, gameObject.transform.position.y+0.5f), Quaternion.identity);
            Instantiate(Damage_1, new Vector2(gameObject.transform.position.x, gameObject.transform.position.y+2f), Quaternion.identity);
            EnemyCollider.enabled = false;
            PlayerController.Bullets+=3;
            Destroy(collider.gameObject);
            EnemyAnimator.SetTrigger("Dead");
        }

        if(collider.gameObject.tag=="Player"){
            EnemyAnimator.SetTrigger("Attack");
            PlayerController.Life-=3;
        }
        
    }

    public void Die(){
        GameManager.Enemy3_Killed++;
        Debug.Log("적3 사망");
        Destroy(gameObject);
    }
}
