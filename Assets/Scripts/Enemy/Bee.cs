using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class Bee : MonoBehaviour
{
    public float moveSpeed = 3.5f;

    private bool atackStarted;
    private bool attackRight;
    bool moveAndAttack;
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
                StartCoroutine(AttackPlayer());
            }
        }
        if (moveAndAttack)
        {
            if(!attackRight)
            {
                transform.position -= Vector3.right * moveSpeed * Time.deltaTime; 
            }else
            {
                transform.position += Vector3.right * moveSpeed * Time.deltaTime;
            }
        }
    }

    IEnumerator AttackPlayer()
    {
        yield return new WaitForSeconds(1.5f);
        transform.rotation = Quaternion.Euler(0, 0, Random.Range(0, -45));
        moveAndAttack = true;
        Invoke(nameof(Deactivate),5);
    }

    void Deactivate()
    {
        gameObject.SetActive(false);
    }
}
