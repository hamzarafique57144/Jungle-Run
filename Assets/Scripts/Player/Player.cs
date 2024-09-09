using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private Animator anim;
    private bool onRight, OnLeft;
    private bool jumped;
    [SerializeField] Button jumpButton;
    bool isJumping = false;

    private void Awake()
    {
        jumpButton.onClick.AddListener(Jump);
    }
    void Start()
    {
        anim = GetComponent<Animator>();
        onRight = true;
        OnLeft = false;
    }

   
    void Update()
    {
        if(!jumped)
        {
            if(onRight)
            {
                anim.Play("RunRight");
            }
            else
            {
                anim.Play("RunLeft");
            }
           
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            if (!jumped)
            {
                if (onRight)
                {
                    anim.Play("RunRight");
                }
                else
                {
                    anim.Play("RunLeft");
                }

            }
        }
    }

    public void Jump()
    {
        if(onRight)
        {
            anim.Play("JumpLeft");
            OnLeft = true;
            onRight = false;
            
        }
        else
        {
            anim.Play("JumpRight");
            
        }
        jumped = true;
        
    }

    void OnRightSide()
    {
        onRight = true;
        OnLeft = false;
        jumped = false;
    }

    void OnLeftSide()
    {
        onRight = false;
        OnLeft = true;
        jumped = false;
    }
}
