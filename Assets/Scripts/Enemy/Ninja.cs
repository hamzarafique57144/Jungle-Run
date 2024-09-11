using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ninja : MonoBehaviour
{
    public GameObject shuriken;

    private float moveSpeed = 5f;
    private float cameraY;

    private bool attackedPlayer;

    private void Start()
    {
        cameraY = Camera.main.transform.position.y - 10f;
    }

    private void Update()
    {
        Move();
        Deactivate();
    }
    private void Move()
    {
        Vector3 temp = transform.position;
        temp.y -= moveSpeed * Time.deltaTime;
        transform.position = temp;

        if(transform.position.y < 0)
        {
            //We reached to the middle of the screen
            if(!attackedPlayer)
            {
                attackedPlayer = true;

                Instantiate(shuriken, transform.position, Quaternion.identity);
            }
        }

    }

    private void Deactivate()
    {
        if(gameObject.transform.position.y < cameraY)
        {
            gameObject.SetActive(false);
        }
    }

}
