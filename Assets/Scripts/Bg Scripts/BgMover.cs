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

    public GameObject[] enemies;
    public GameObject[] spawnPositioins;
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
            //Spawn Enemies
            SpawnEnemies();
        }

        
    }

    void SpawnEnemies()
    {
        //Frequencies of spawning enemies
        if(Random.Range(0,10)>0)
        {
            int randomEnemyIndex = Random.Range(0, enemies.Length);
            if(randomEnemyIndex == 0)
            {
                //Flag enemy---Needs to be spawned in middle
                Instantiate(enemies[randomEnemyIndex], new Vector3(0, transform.position.y,3), Quaternion.identity);
            }
            else
            {
                GameObject enemyObj = Instantiate(enemies[randomEnemyIndex]);
                Vector3 enemyScale = enemyObj.transform.localScale;

                if(Random.Range(0,2)>0)
                {
                    enemyObj.transform.position = spawnPositioins[0].transform.position;

                    enemyScale.x = -Mathf.Abs(enemyScale.x);
                }
                else
                {
                    enemyObj.transform.position = spawnPositioins[1].transform.position;

                    enemyScale.x = Mathf.Abs(enemyScale.x);
                }
                enemyObj.transform.localScale = enemyScale;
            }
            
        }
    }
}
