using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnerWall : MonoBehaviour
{
    [SerializeField]
    private GameObject[] obj;

    private float X1 = -10f;
    private float X2 = 10f;
    private float randX;
    private int randObj;
    Vector2 whereToSpawn;

    private float timeBtwSpawn1;
    private float timeBtwSpawn2;
    private float startTimeBtwSpawn = 5.0f;

    private void Update()
    {
        if (timeBtwSpawn1 <= 0f)
        {
            randX = Random.Range(0f, 100f);
            if (randX <= 70f)
            {
                int i = Random.Range(0, obj.Length);
                whereToSpawn = new Vector2(X1, transform.position.y);
                Instantiate(obj[i], whereToSpawn, Quaternion.identity);
            }
            timeBtwSpawn1 = startTimeBtwSpawn;
            if (startTimeBtwSpawn > 0.45f)
            {
                startTimeBtwSpawn -= 0.0025f;
            }
            else if (startTimeBtwSpawn < 0.45f)
            {
                startTimeBtwSpawn = 0.45f;
            }
        }
        else
        {
            timeBtwSpawn1 -= Time.deltaTime;
        }

        if (timeBtwSpawn2 <= 0f)
        {
            randX = Random.Range(0f, 100f);
            if (randX <= 70f)
            {
                int i = Random.Range(0, obj.Length);
                whereToSpawn = new Vector2(X2, transform.position.y);
                Instantiate(obj[i], whereToSpawn, Quaternion.identity);
            }
            timeBtwSpawn2 = startTimeBtwSpawn;
            if (startTimeBtwSpawn > 0.8f)
            {
                startTimeBtwSpawn -= 0.05f;
            }
            else if (startTimeBtwSpawn < 0.8f)
            {
                startTimeBtwSpawn = 0.8f;
            }
        }
        else
        {
            timeBtwSpawn2 -= Time.deltaTime;
        }
    }
}
