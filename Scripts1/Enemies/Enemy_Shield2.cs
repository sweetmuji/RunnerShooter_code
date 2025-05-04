using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy_Shield2 : MonoBehaviour
{
    public GameObject Damage1;
    public GameObject AddSword;
    public int Life = 3;
    private BoxCollider2D boxCollider2D;
    private Animator animator;
    private Transform LifeObject;
    private TextMesh LifeText;
    void Start()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
        LifeObject = transform.Find("LifeText");
        LifeText = LifeObject.GetComponent<TextMesh>();
    }

    // Update is called once per frame
    void Update()
    {
        LifeText.text = ""+Life;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag=="Player"){
            PlayerController.Life--;
        }

        if(collider.gameObject.tag=="Attack"){
            Destroy(collider.gameObject);
            Life--;
            Instantiate(Damage1, new Vector2(gameObject.transform.position.x, gameObject.transform.position.y+2f), Quaternion.identity);
            
            if(Life<=0){
                boxCollider2D.enabled = false;
                DieTrigger();
                }
        }
    }

    public void DieTrigger()
    {
        Instantiate(AddSword, new Vector2(gameObject.transform.position.x, gameObject.transform.position.y+0.5f), Quaternion.identity);
        PlayerController.Bullets+=3;
        animator.SetTrigger("Die");
    }

    public void Die()
    {
        GameManager.Enemy_Shiled2_Killed++;
        Debug.Log("방패병2 사망");
        Destroy(gameObject);
    }
}
