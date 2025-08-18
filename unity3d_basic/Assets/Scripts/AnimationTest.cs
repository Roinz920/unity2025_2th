using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AnimationTest : MonoBehaviour
{
    Animator animator;
    float speed;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        //if(Keyboard.current.tKey.wasPressedThisFrame){}

        if(Input.GetKey(KeyCode.T))
        {
            speed += Time.deltaTime;
            animator.SetFloat("Speed", speed);
        }
        else if (Input.GetKeyUp(KeyCode.T))
        {
            speed -= Time.deltaTime*2                ;
            if (speed < 0) speed = 0;

        }
    }
}
