using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class skip : MonoBehaviour
{
    private float timeSum;
    public void skipTitle(){
        SceneManager.LoadScene("MainMenu");
    }

    private void Update()
    {
        timeSum+=Time.deltaTime;

        if(timeSum>=2.0f){
            SceneManager.LoadScene("MainMenu");
        }   
    }
}
