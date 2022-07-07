using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnerCoin : MonoBehaviour
{
    [SerializeField]
    private GameObject obj;
    private float randX;
    private float randX2;
    Vector2 whereToSpawn;
    Vector2 whereToSpawn2;
    private float timeBtwSpawn = 2f;
    private float startTimeBtwSpawn = 4.4f;

    private void Update()
    {
        if (timeBtwSpawn <= 0f)
        {
            float randSpawn = Random.Range(0.0f, 100.0f);
            float _randDoubleSpawn = Random.Range(0.0f, 100.0f);

            if (randSpawn <= 44.0f)
            {
                randX = Random.Range(-7.1f, 7.1f);
                whereToSpawn = new Vector2(randX, transform.position.y);
                Instantiate(obj, whereToSpawn, Quaternion.identity);
            }
            timeBtwSpawn = startTimeBtwSpawn;
            if (startTimeBtwSpawn > 0.6f)
            {
                startTimeBtwSpawn -= 0.005f;
            }
            else if (startTimeBtwSpawn < 0.6f)
            {
                startTimeBtwSpawn = 0.6f;
            }
        }
        else
        {
            timeBtwSpawn -= Time.deltaTime;
        }
    }
}