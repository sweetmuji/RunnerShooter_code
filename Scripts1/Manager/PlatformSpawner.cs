using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject Left_Platform;
    public GameObject Right_Platform;
    public GameObject Mid_Platform;
    public GameObject faster;
    public GameObject addBullet;
    public GameObject addLife;
    public GameObject addSkill;
    public GameObject addCoin;
    public GameObject DeathSound;
    //적
    public GameObject Enemy;
    public GameObject Enemy2;
    public GameObject Enemy3;
    public GameObject Enemy_Shield;
    public GameObject Enemy_Shield2;
    public GameObject Enemy_Archer;
    //스폰 속도
    public int Faster_Every_N_Platforms = 10;
    public float SpawnRate = 2f;
    private int SpawnCount = 0;
    private float Ypos;
    private float timeSum = 0f;
    private int SpawnBullet;
    private int SpawnLife;
    private int SpawnSkill;
    //적 생성 확률
    private int SpawnEnemy;
    void Start()
    {

    }

    // x=11 12 13 y= -3 to 1 )
    void Update()
    {
        timeSum+=Time.deltaTime;

        if(timeSum>=SpawnRate&&Scrolling.Speed!=0f){
            SpawnCount++;
            timeSum=0f;
            Ypos = UnityEngine.Random.Range(-3, 2);
            Instantiate(Left_Platform, new Vector2(18, Ypos), Quaternion.identity);
            Instantiate(Mid_Platform, new Vector2(19, Ypos), Quaternion.identity);
            Instantiate(Mid_Platform, new Vector2(20, Ypos), Quaternion.identity);
            Instantiate(Mid_Platform, new Vector2(21, Ypos), Quaternion.identity);
            Instantiate(Mid_Platform, new Vector2(22, Ypos), Quaternion.identity);
            Instantiate(Mid_Platform, new Vector2(23, Ypos), Quaternion.identity);
            Instantiate(Right_Platform, new Vector2(24, Ypos), Quaternion.identity);

            //탄환 스폰 ( 10% 확률 )
            SpawnBullet = UnityEngine.Random.Range(1, 11);
            if(SpawnBullet==1){
                Instantiate(addBullet, new Vector2(19, Ypos+0.75f), Quaternion.identity);
            }

            //체력 스폰 ( 20% 확률 )
            SpawnLife = UnityEngine.Random.Range(1, 6);
            if(SpawnLife==1){
                Instantiate(addLife, new Vector2(19, Ypos+1.0f), Quaternion.identity);
            }

            //스킬 스폰 ( 5% 확률 )
            SpawnSkill = UnityEngine.Random.Range(1, 21);
            if(SpawnSkill==2){
                Instantiate(addSkill, new Vector2(20, Ypos+1.0f), Quaternion.identity);
            }

            //코인 스폰 ( 100% 확률 )
            Instantiate(addCoin, new Vector2(20, Ypos+1.0f), quaternion.identity);

            // 18 19 20 21 22 23 24
            //적 스폰 레벨 1
            if(GameManager.Level<6){
                SpawnEnemy = UnityEngine.Random.Range(1, 5);
                if(SpawnEnemy==1||SpawnEnemy==2){ //적 스폰 50%
                    Instantiate(Enemy, new Vector2(23, Ypos+0.5f), quaternion.identity);
                }

                SpawnEnemy = UnityEngine.Random.Range(1, 4);
                if(SpawnEnemy==1){ //방패병 스폰 33%
                    Instantiate(Enemy_Shield, new Vector2(24, Ypos+0.5f), quaternion.identity);
                }
            }

            //적 스폰 레벨 2
            if(GameManager.Level>=6&&GameManager.Level<10){
                SpawnEnemy = UnityEngine.Random.Range(1, 5);
                if(SpawnEnemy==1||SpawnEnemy==2){ //50% 적 생성 이중 25%로 일반 적 25%로 방패병 
                    if(SpawnEnemy==1){
                        Instantiate(Enemy2, new Vector2(21, Ypos+0.5f), quaternion.identity);
                    }
                    else if(SpawnEnemy==2){
                        Instantiate(Enemy_Shield, new Vector2(19, Ypos+0.5f), quaternion.identity);
                    }
                }
                SpawnBullet = UnityEngine.Random.Range(1, 7);
                if(SpawnBullet==1){ //16%로 아처 스폰
                    Instantiate(Enemy_Archer, new Vector2(23, Ypos+0.5f), quaternion.identity);
                } 
            }

            //적 스폰 레벨 3
            if(GameManager.Level>=10&&GameManager.Level<17){
                SpawnEnemy = UnityEngine.Random.Range(1, 5);
                if(SpawnEnemy==1||SpawnEnemy==2){  //50% 적 생성
                    if(SpawnEnemy==1){
                        Instantiate(Enemy_Shield2, new Vector2(19, Ypos+0.5f), quaternion.identity);
                    }
                    else if(SpawnEnemy==2){
                        Instantiate(Enemy_Shield, new Vector2(22, Ypos+0.5f), quaternion.identity);
                    }
                }
                SpawnBullet = UnityEngine.Random.Range(1, 6);
                if(SpawnBullet==1){ //20%로 아처 스폰
                    Instantiate(Enemy_Archer, new Vector2(23, Ypos+0.5f), quaternion.identity);
                } 
            }

            //적 스폰 레벨4
            if(GameManager.Level>=17&&GameManager.Level<25){
                SpawnEnemy = UnityEngine.Random.Range(1, 4);
                if(SpawnEnemy==1||SpawnEnemy==2){ //66% 적 생성
                    if(SpawnEnemy==1){
                        Instantiate(Enemy_Shield2, new Vector2(18, Ypos+0.5f), quaternion.identity);
                    }
                    else if(SpawnEnemy==2){
                        Instantiate(Enemy3, new Vector2(22, Ypos+0.5f), quaternion.identity);
                    }
                }
                SpawnBullet = UnityEngine.Random.Range(1, 4);
                if(SpawnBullet==1){ //33%로 아처 스폰
                    Instantiate(Enemy_Archer, new Vector2(23, Ypos+0.5f), quaternion.identity);
                } 
            }

            //적 스폰 레벨5
            if(GameManager.Level>=25&&GameManager.Level<GameManager.MaxLV){
                SpawnEnemy = UnityEngine.Random.Range(1, 3);
                if(SpawnEnemy==1||SpawnEnemy==2){ //100% 적 생성
                    if(SpawnEnemy==1){
                        Instantiate(Enemy3, new Vector2(21, Ypos+0.5f), quaternion.identity);
                    }
                    else if(SpawnEnemy==2){
                        Instantiate(Enemy_Shield, new Vector2(19, Ypos+0.5f), quaternion.identity);
                    }
                }
                SpawnBullet = UnityEngine.Random.Range(1, 3);
                if(SpawnBullet==1){ //50%로 아처 스폰
                    Instantiate(Enemy_Archer, new Vector2(23, Ypos+0.5f), quaternion.identity);
                } 
            }

            //적 스폰 레벨6
            if(GameManager.Level>=GameManager.MaxLV){
                SpawnEnemy = UnityEngine.Random.Range(1, 4);
                if(SpawnEnemy==1||SpawnEnemy==2){ //66% 적 생성
                    if(SpawnEnemy==1){
                        Instantiate(Enemy_Shield2, new Vector2(20, Ypos+0.5f), quaternion.identity);
                    }
                    else if(SpawnEnemy==2){
                        Instantiate(Enemy3, new Vector2(21, Ypos+0.5f), quaternion.identity);
                    }
                }
                SpawnBullet = UnityEngine.Random.Range(1, 4);
                if(SpawnBullet==1){ //33%로 아처 스폰
                    Instantiate(Enemy_Archer, new Vector2(23, Ypos+0.5f), quaternion.identity);
                } 
            }

            //적 스폰 레벨7
            if(GameManager.Level>=25&&GameManager.Level<GameManager.MaxLV){
                SpawnEnemy = UnityEngine.Random.Range(1, 3);
                if(SpawnEnemy==1||SpawnEnemy==2){ //100% 적 생성
                    if(SpawnEnemy==1){
                        Instantiate(Enemy3, new Vector2(20, Ypos+0.5f), quaternion.identity);
                    }
                    else if(SpawnEnemy==2){
                        Instantiate(Enemy_Shield2, new Vector2(20, Ypos+0.5f), quaternion.identity);
                    }
                }
                //100%로 아처 스폰
                Instantiate(Enemy_Archer, new Vector2(23, Ypos+0.5f), quaternion.identity);
            }
        }

        if(SpawnCount>=Faster_Every_N_Platforms&&Scrolling.Speed!=0f){
            if(GameManager.Level<GameManager.MaxLV){
            SpawnCount=0;
            Scrolling.Speed+=0.5f;
            GameManager.Level++;
            Debug.Log("속도 증가:"+Scrolling.Speed);
            faster.SetActive(true);
            }
        }
    }
}
