using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using UnityEngine;

public class BgMover : MonoBehaviour
{
    public float moveSpeed = 5f;
    private GameObject[] sideBounds;
    private float cameraY;
    private float boundHeight;
    void Start()
    {
        sideBounds = GameObject.FindGameObjectsWithTag("SideBound");
        cameraY = Camera.main.gameObject.transform.position.y-15f;
        boundHeight = GetComponent<BoxCollider2D>().bounds.size.y;
    }

    
    void Update()
    {

        Move();
        Reposition();
    }

    private void Move()
    {
        Vector3 temp = transform.position;
        temp.y -= moveSpeed * Time.deltaTime;
        transform.position = temp;

    }

    void Reposition()
    {
        if(transform.position.y < cameraY)
        {
            float highestBoundsY = sideBounds[0].transform.position.y;
            for(int i=1; i<sideBounds.Length;i++)
            {
                if(highestBoundsY < sideBounds[i].transform.position.y)
                {
                    highestBoundsY = sideBounds[i].transform.position.y;
                }
            }
            Vector3 temp = transform.position;
            temp.y = highestBoundsY + boundHeight-1f;
            transform.position = temp;
        }

        
    }
}
