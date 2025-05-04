using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager dataManager;
    void Awake()
    {
        //싱글톤 구현
        if(dataManager==null){
            dataManager = this;
            DontDestroyOnLoad(gameObject);
        }
        else{
            Destroy(gameObject);
            return;
        }
    }

    void Update()
    {

    }

    public void AddGold(int GetGold){
        //GetGold 만큼 설정
        PlayerPrefs.SetInt("GOLD", PlayerPrefs.GetInt("GOLD")+GetGold);
    }

    public void UseGold(int Price){
        //Price만큼 골드를 차감 
        PlayerPrefs.SetInt("GOLD", PlayerPrefs.GetInt("GOLD")-Price);
    }

    public int ShowGold(){
        //GOLD 값을 리턴
        return PlayerPrefs.GetInt("GOLD");
    }
}
