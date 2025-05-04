using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Platform_Skill : MonoBehaviour
{
    public static int SkillCount = 5; 
    public Text SkillCounter;
    public GameObject emer1;
    public GameObject emer2;
    public GameObject emer3;
    public GameObject minus1;
    private PlayerController playerController;
    void Start()
    {
        playerController = FindAnyObjectByType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(playerController!=null){
            if(Input.GetKeyDown(KeyCode.M)){
            UseSkill();
            }
        }
        
        SkillCounter.text = ""+SkillCount;
    }

    public void UseSkill(){
        if(SkillCount>0){
            GameManager.SkillUsed++;
            SkillCount--;
            Instantiate(emer1, new Vector2(playerController.transform.position.x+2, playerController.transform.position.y-1), Quaternion.identity);
            Instantiate(emer2, new Vector2(playerController.transform.position.x+3, playerController.transform.position.y-1), Quaternion.identity);
            Instantiate(minus1, new Vector2(playerController.transform.position.x+3, playerController.transform.position.y+1), Quaternion.identity);
            Instantiate(emer3, new Vector2(playerController.transform.position.x+4, playerController.transform.position.y-1), Quaternion.identity);
        }
    }
}
