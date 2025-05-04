using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Lobby : MonoBehaviour
{
    public Text GoldText;
    private AudioSource audioSource;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
            Application.Quit();
        }

        if(Input.GetKeyDown(KeyCode.Space)){
            SceneManager.LoadScene("Level");
        }

        GoldText.text = ""+PlayerPrefs.GetInt("GOLD");
    }

    public void gameStart(){
        audioSource.Play();
        Debug.Log("시작 버튼 호출");
        SceneManager.LoadScene("Level");
    }
}
