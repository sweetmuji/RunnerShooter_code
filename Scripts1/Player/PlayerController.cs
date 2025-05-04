using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float JumpForce = 5f;
    public static int Bullets = 15;
    public static int Life = 10;
    public GameObject Bullet;
    public GameObject JumpResetText;
    public GameObject DamageEffect;
    public GameObject jumpUsed1;
    public GameObject jumpUsed2;
    public GameObject jumpUsed3;
    public GameObject DeathSound;
    public Text Bullet_Current;
    public Text Life_Current;
    private int iniBullet;
    private int iniLife;
    private int JumpCount = 0;
    private Rigidbody2D playerRigidbody;
    private Animator PlayerAnimator;
    private bool isDead = false;
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        PlayerAnimator = GetComponent<Animator>();
        iniBullet=Bullets;
        iniLife=Life;
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetKeyDown(KeyCode.Space)&&JumpCount<3){
            JumpEnter();
        }

        if(Input.GetKeyUp(KeyCode.Space)){
            JumpExit();
        }

        if(Input.GetKeyDown(KeyCode.N)){
            AttackTrigger();
        }

        if(Life<=0){
            DieTrigger();
        }

        Bullet_Current.text= ""+Bullets;
        Life_Current.text= ""+Life;

        //점프 카운터 UI
        if(JumpCount==1){
            jumpUsed3.SetActive(true);
            jumpUsed2.SetActive(false);
            jumpUsed1.SetActive(false);
        }

        if(JumpCount==2){
            jumpUsed3.SetActive(true);
            jumpUsed2.SetActive(true);
            jumpUsed1.SetActive(false);
        }

        if(JumpCount==3){
            jumpUsed3.SetActive(true);
            jumpUsed2.SetActive(true);
            jumpUsed1.SetActive(true);
        }

        if(JumpCount==0){
            jumpUsed3.SetActive(false);
            jumpUsed2.SetActive(false);
            jumpUsed1.SetActive(false);
        }
    }

    void OnTriggerEnter2D(Collider2D collider){
        if(collider.gameObject.tag=="Die"){
            DieTrigger();
        }

        if(collider.gameObject.tag=="Enemy"){
            DamageEffect.gameObject.SetActive(true);
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag=="Platform"&&other.contacts[0].normal.y>=0.7f){
            if(JumpCount>0){
                JumpResetText.SetActive(true);
            }
            JumpCount=0;
        } 
    }
    public void DieTrigger()
    {
        Scrolling.Speed = 0f;
        Die();
    }

    public void Attack(){
        GameManager.SwordUsed++;
        Instantiate(Bullet, new Vector2(gameObject.transform.position.x+1, gameObject.transform.position.y+0.5f), quaternion.identity);
        Bullets--;
    }

    public void AttackTrigger(){
        if(Bullets>=3){
            PlayerAnimator.SetTrigger("Attack3");
        }
        else if(Bullets==2){
            PlayerAnimator.SetTrigger("Attack2");
        }
        else if(Bullets==1){
            PlayerAnimator.SetTrigger("Attack1");
        }
        else{
            Debug.Log("탄환이 부족합니다.");
        }
    }

    public void JumpEnter(){
        if(JumpCount<3){
            Debug.Log("점프 버튼 클릭");
            playerRigidbody.linearVelocity = new Vector2(0, JumpForce);
            JumpCount++;
        }
        else{
            Debug.Log("점프 횟수가 초과되었습니다.");
        }
    }

    public void JumpExit(){
        Debug.Log("y축 낙하 속도 가속");
        if(playerRigidbody.linearVelocity.y>=0){
            playerRigidbody.linearVelocity = new Vector2(0, playerRigidbody.linearVelocity.y*0.5f);
        }
        else if(playerRigidbody.linearVelocity.y<=0){
            playerRigidbody.linearVelocity = new Vector2(0, playerRigidbody.linearVelocity.y*2f);
        }
    }

    public void Die(){
        Instantiate(DeathSound, new Vector2(transform.position.x, transform.position.y), quaternion.identity);
        Scrolling.Speed=0f;
        Bullets = iniBullet;
        Life = iniLife;
        GameManager.Level=0;
        Destroy(gameObject);
        //SceneManager.LoadScene("MainMenu");
        Debug.Log("속도 초기화");
    }
}
