using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shuriken : MonoBehaviour
{
    private bool attackRight;
    private float attackSpeed = 6f;

    private void Start()
    {
        transform.rotation = Quaternion.Euler(0, 0, Random.Range(-45, 45));
        if(transform.position.x > 0)
        {
            attackRight = false;
        }
        else
        {
            attackRight = true;
        }

        Invoke(nameof(Deactivate), 5f);
    }

    private void Update()
    {
        if(!attackRight)
        {
            //Left
            transform.position -= Vector3.right * attackSpeed * Time.deltaTime;
        }
        else
        {
            //Right
            transform.position += Vector3.right * attackSpeed * Time.deltaTime;
        }
    }
    private void Deactivate()
    {
        gameObject.SetActive(false);
    }
}
