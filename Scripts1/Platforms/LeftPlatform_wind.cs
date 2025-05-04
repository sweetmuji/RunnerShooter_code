using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftPlatform_wind : MonoBehaviour
{
    private AudioSource audioSource;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnTriggerEnter2D(Collider2D collider){
        if(collider.gameObject.tag=="Wind"&&GameManager.Level>=10){
            audioSource.Play();
        }
    }
}
