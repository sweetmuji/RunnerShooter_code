using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public float StartSpeed = 13f;
    public static int MaxLV = 36;
    public static int Level;
    public int IniBulletsSet = 15;
    public Text Score;
    public Text GOLD;
    public GameObject BestIndicator;
    public GameObject SkillButton;
    public GameObject RestartButton;
    public GameObject GameOverObject;
    public GameObject attackButton;
    public GameObject BG_lv1;
    public GameObject BG_lv2;
    public GameObject BG_lv3;
    public GameObject BG_lv4;
    public GameObject BG_lv5;
    public GameObject BG_lv6;
    public GameObject BulletBox;
    public GameObject LifeBox;
    public GameObject SkillBox;
    private int GoldBefore;
    private PlayerController playerController;
    private DataManager datamanager;
    private int IndiSpawned = 0;
    private float SurvialTime = 0f;
    private int FinalScore;
    private bool isCalculated;

    //점수 계산
    public static int SwordUsed;
    public static int SkillUsed;
    public static int Enemy1_Killed;
    public static int Enemy2_Killed;
    public static int Enemy3_Killed;
    public static int Enemy_Archer_Killed;
    public static int Enemy_Shiled1_Killed;
    public static int Enemy_Shiled2_Killed;
    //점수 메시지
    public Text FinalScoreText;
    public Text BestScoreText;
    public Text SwordUsedText;
    public Text SkillUsedText;
    public Text Enemy1Text;
    public Text Enemy2Text;
    public Text Enemy3Text;
    public Text Shield1Text;
    public Text Shield2Text;
    public Text ArcherText;

    void Start()
    {
        Platform_Skill.SkillCount = 5;
        Scrolling.Speed = StartSpeed;
        playerController = FindAnyObjectByType<PlayerController>();
        datamanager = FindAnyObjectByType<DataManager>();
        Level = 0;
        GoldBefore = PlayerPrefs.GetInt("GOLD");

        //점수 초기화 
        isCalculated = false;
        FinalScore = 0;
        SwordUsed = 0;
        Enemy1_Killed = 0;
        Enemy2_Killed = 0;
        Enemy3_Killed = 0;
        Enemy_Archer_Killed = 0;
        Enemy_Shiled1_Killed = 0;
        Enemy_Shiled2_Killed = 0;

        //아이템 구매 여부 확인, 아이템 생성
        //탄환 20발
        if(PlayerPrefs.GetInt("BulletShop")==1){ 
            Instantiate(BulletBox, new Vector2(0, -2.5f), quaternion.identity);
            Instantiate(BulletBox, new Vector2(0.2f, -2.5f), quaternion.identity);
            Instantiate(BulletBox, new Vector2(0.4f, -2.5f), quaternion.identity);
            Instantiate(BulletBox, new Vector2(0.6f, -2.5f), quaternion.identity);
            Instantiate(BulletBox, new Vector2(0.8f, -2.5f), quaternion.identity);
            Instantiate(BulletBox, new Vector2(1.0f, -2.5f), quaternion.identity);
            Instantiate(BulletBox, new Vector2(1.2f, -2.5f), quaternion.identity);
            Instantiate(BulletBox, new Vector2(1.4f, -2.5f), quaternion.identity);
            Instantiate(BulletBox, new Vector2(1.6f, -2.5f), quaternion.identity);
            Instantiate(BulletBox, new Vector2(1.8f, -2.5f), quaternion.identity);
            PlayerPrefs.SetInt("BulletShop", 0);
        }

        //생명 7개
        if(PlayerPrefs.GetInt("LifeShop")==1){
            Instantiate(LifeBox, new Vector2(0.4f, -2.5f), quaternion.identity);
            Instantiate(LifeBox, new Vector2(0.6f, -2.5f), quaternion.identity);
            Instantiate(LifeBox, new Vector2(0.8f, -2.5f), quaternion.identity);
            Instantiate(LifeBox, new Vector2(1.0f, -2.5f), quaternion.identity);
            Instantiate(LifeBox, new Vector2(1.2f, -2.5f), quaternion.identity);
            PlayerPrefs.SetInt("LifeShop", 0);
        }

        //스킬 10개
        if(PlayerPrefs.GetInt("SkillShop")==1){
            Instantiate(SkillBox, new Vector2(0, -2.5f), quaternion.identity);
            Instantiate(SkillBox, new Vector2(0.2f, -2.5f), quaternion.identity);
            Instantiate(SkillBox, new Vector2(0.4f, -2.5f), quaternion.identity);
            Instantiate(SkillBox, new Vector2(0.6f, -2.5f), quaternion.identity);
            Instantiate(SkillBox, new Vector2(0.8f, -2.5f), quaternion.identity);
            PlayerPrefs.SetInt("SkillShop", 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //레벨 관리
        if(Level==6){ //lv2
            BG_lv1.SetActive(false);
            BG_lv2.SetActive(true);
        }

        if(Level==10){  //lv3
            BG_lv2.SetActive(false);
            BG_lv3.SetActive(true);
        }

        if(Level==17){ //lv4
            BG_lv3.SetActive(false);
            BG_lv4.SetActive(true);
        }

        if(Level==25){ //lv5
            BG_lv4.SetActive(false);
            BG_lv5.SetActive(true);
        }

        if(Level==MaxLV){ //lv6
            BG_lv5.SetActive(false);
            BG_lv6.SetActive(true);
        }
        
        //골드 표시
        GOLD.text = ""+datamanager.ShowGold();
        Score.text = "획득한 골드: "+(PlayerPrefs.GetInt("GOLD")-GoldBefore);

        //최고 거리 인디케이터
        if(SurvialTime>PlayerPrefs.GetFloat("BestSurvival")&&IndiSpawned==0){
            IndiSpawned++;
            Instantiate(BestIndicator, new Vector2(19, -7), quaternion.identity);
        }

        //최고 점수 저장
        SurvialTime+=Time.deltaTime;

        //종료 화면
        if(playerController==null){
            //생존시간 저장
            if(SurvialTime>PlayerPrefs.GetFloat("BestSurvival")){
            PlayerPrefs.SetFloat("BestSurvival", SurvialTime);
            }

            if(isCalculated==false){
                CalFinalScore();
                isCalculated=true;
            }

            //메뉴로 이동
            if(Input.GetKey(KeyCode.Escape)){
                ReStart();
            }

            //점수 텍스트 갱신
            ShowScore();
            FinalScoreText.text = "최종 점수: "+FinalScore;

            SkillButton.SetActive(false);
            attackButton.SetActive(false);
            RestartButton.SetActive(true);
            GameOverObject.SetActive(true);
            
            if(Input.GetKeyDown(KeyCode.R)){
                ReStart();
        }
        }
    }

    public void ReStart(){
        SceneManager.LoadScene("MainMenu");
        Debug.Log("로비로 이동");
    }

    int CalFinalScore(){
    FinalScore = SwordUsed 
               + Enemy1_Killed 
               + (Enemy2_Killed * 2) 
               + (Enemy3_Killed * 3)
               + (Enemy_Archer_Killed * 2) 
               + (Enemy_Shiled1_Killed * 3) 
               + (Enemy_Shiled2_Killed * 4);
        
        if(FinalScore>PlayerPrefs.GetInt("BESTSCORE")){
            PlayerPrefs.SetInt("BESTSCORE", FinalScore);
        }

        return FinalScore;
    }

    void ShowScore(){
        SwordUsedText.text = "사용한 탄환: "+SwordUsed;
        SkillUsedText.text = "사용한 스킬: "+SkillUsed;
        Enemy1Text.text = "처치한 해골 병사: "+Enemy1_Killed;
        Enemy2Text.text = "처치한 기사: "+Enemy2_Killed;
        Enemy3Text.text = "처치한 악마 근접병: "+Enemy3_Killed;
        Shield1Text.text = "처치한 방패병: "+Enemy_Shiled1_Killed;
        Shield2Text.text = "처치한 강화 방패병: "+Enemy_Shiled2_Killed;
        ArcherText.text = "처치한 궁수: "+Enemy_Archer_Killed;
        BestScoreText.text = "최고 점수: "+PlayerPrefs.GetInt("BESTSCORE");
    }
}
