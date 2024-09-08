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
    }

    public void Jump()
    {
        if(onRight)
        {
            anim.Play("JumpLeft");
        }
        else
        {
            anim.Play("JumpRight");
        }
        jumped = true;
    }
}
