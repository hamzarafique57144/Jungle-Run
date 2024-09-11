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
    [Header("Auido")]
    [SerializeField] AudioSource audioKill, audioJump;
    [SerializeField] AudioClip deadSound;

    private bool playerAlive = true;

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
        if(playerAlive)
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

            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (!jumped)
                {
                    if (playerAlive)
                    {
                        if (onRight)
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
                        audioJump.Play();

                    }


                }
            }
        }
    }

    public void Jump()
    {
        if(playerAlive)
        {
            if (onRight)
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
            audioJump.Play();

        }

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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(jumped)
        {
            if(collision.gameObject.CompareTag("Enemy"))
            {
                collision.gameObject.SetActive(false);
                audioKill.Play();
            }
        }
        else
        {
            if(collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("EnemyTree"))
            {
                PlayerDied();
            }
        }
    }
    void PlayerDied()
    {
        audioKill.clip = deadSound;
        audioKill.Play();

        playerAlive = false;
        if(gameObject.transform.position.x >0)
        {
            anim.Play("PlayerDiedRight");
        }
        else
        {
            anim.Play("PlayerDiedLeft");
        }

        //GameManager.Instance.GameOver();
        Time.timeScale = 0f;
    }
}
