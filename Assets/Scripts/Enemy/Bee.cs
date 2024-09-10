using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class Bee : MonoBehaviour
{
    public float moveSpeed = 3.5f;

    private bool atackStarted;
    private bool attackRight;
    private void Start()
    {
        if(transform.position.x > 0)
        {
            attackRight = false;
        }
        else
        {
            attackRight = true;
        }
       
    }

    private void Update()
    {
        BeeAtack();
    }
    void BeeAtack()
    {
        if(transform.position.y > 0)
        {
            Vector3 temp = transform.position;
            temp.y -= moveSpeed * Time.deltaTime;
            transform.position = temp;
        }
        else
        {
            //We reached the center of the screen
            if(!atackStarted)
            {
                atackStarted = true;
            }
        }
    }
}
