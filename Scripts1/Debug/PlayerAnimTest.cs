using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerAnimTest : MonoBehaviour
{
    Animator PlayerAnimator;
    void Start()
    {
        PlayerAnimator=GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Z)){
            PlayerAnimator.SetTrigger("Attack");
        }

    }
    
}
