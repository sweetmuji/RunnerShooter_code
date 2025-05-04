using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isPlayerDead : MonoBehaviour
{
    private PlayerController playerController;
    void Start()
    {
        playerController = FindAnyObjectByType<PlayerController>();
    }

    void Update()
    {
        if(playerController==null){
            gameObject.SetActive(false);
        }
    }
}
