using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    public int BulletPrice = 100;
    public int LifePrice = 100;
    public int SkillPrice = 100;
    public GameObject Bullet_txt;
    public GameObject Life_txt;
    public GameObject Skill_txt;
    public GameObject Bullet_SoldOut;
    public GameObject Life_SoldOut;
    public GameObject Skill_SoldOut;
    public GameObject NotEnoughGOLD;
    public GameObject AlreadyBought;
    private bool isBulletSold = false;
    private bool isLifeSold = false;
    private bool isSkillSold = false;
    private DataManager datamanager;
    void Start()
    {
        datamanager = FindAnyObjectByType<DataManager>();
        //Playerprefs에서 0이면 구매 안 함, 1이면 구매함
        PlayerPrefs.SetInt("BulletShop", 0);
        PlayerPrefs.SetInt("LifeShop", 0);
        PlayerPrefs.SetInt("SkillShop", 0);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void BuyBullet()
    {
        if(isBulletSold==false){
            if(PlayerPrefs.GetInt("GOLD")>=BulletPrice){
                isBulletSold=true;
                PlayerPrefs.SetInt("GOLD", PlayerPrefs.GetInt("GOLD")-BulletPrice);
                PlayerPrefs.SetInt("BulletShop", 1);
                Bullet_txt.gameObject.SetActive(false);
                Bullet_SoldOut.gameObject.SetActive(true);
            }
            else{
                NotEnoughGOLD.SetActive(true);
            }
        }
        else{
            AlreadyBought.gameObject.SetActive(true);
        }
    }

    public void BuyLife()
    {
        if(isLifeSold==false){
            if(PlayerPrefs.GetInt("GOLD")>=LifePrice){
                isLifeSold=true;
                PlayerPrefs.SetInt("GOLD", PlayerPrefs.GetInt("GOLD")-LifePrice);
                PlayerPrefs.SetInt("LifeShop", 1);
                Life_txt.gameObject.SetActive(false);
                Life_SoldOut.gameObject.SetActive(true);
            }
            else{
                NotEnoughGOLD.SetActive(true);
            }
        }
        else{
            AlreadyBought.gameObject.SetActive(true);
        }
    }

    public void BuySkill()
    {
        if(isSkillSold==false){
            if(PlayerPrefs.GetInt("GOLD")>=SkillPrice){
                isSkillSold=true;
                PlayerPrefs.SetInt("GOLD", PlayerPrefs.GetInt("GOLD")-SkillPrice);
                PlayerPrefs.SetInt("SkillShop", 1);
                Skill_txt.gameObject.SetActive(false);
                Skill_SoldOut.gameObject.SetActive(true);
            }
            else{
                NotEnoughGOLD.SetActive(true);
            }
        }
        else{
            AlreadyBought.gameObject.SetActive(true);
        }
    }
}
