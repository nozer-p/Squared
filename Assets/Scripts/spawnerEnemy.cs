using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnerEnemy : MonoBehaviour
{
    [SerializeField]
    private GameObject[] obj;
    private float randX;
    private float randX2;
    Vector2 whereToSpawn;
    Vector2 whereToSpawn2;
    private float timeBtwSpawn;
    private float startTimeBtwSpawn = 2.25f;
    private float randDoubleSpawn = 5.0f;

    private void Update()
    {
        if (timeBtwSpawn <= 0.0f)
        {
            float randSpawn = Random.Range(0.0f, 100.0f);
            float _randDoubleSpawn = Random.Range(0.0f, 100.0f);

            bool rDs = false;
            int i;
            float speed = 0.0f;
            if (PlayerPrefs.HasKey("SpeedObj"))
            {
                speed = PlayerPrefs.GetFloat("SpeedObj");
            }

            if (speed > 20.0f)
            {
                if (randDoubleSpawn >= _randDoubleSpawn)
                {
                    randDoubleSpawn += 0.5f;
                    rDs = true;
                }
                else if (randDoubleSpawn > 20.0f)
                {
                    randDoubleSpawn = 20.0f;
                    rDs = true;
                }
            }

            
            if (randSpawn <= 7.0f)
            {
                if (speed > 28.0f)
                {
                    randX = Random.Range(-7.1f, 7.1f);
                    if (rDs)
                    {
                        if (randX >= -6.75f && randX < 0f)
                        {
                            float X2 = Random.Range(4, 6.75f);
                            randX2 = randX + X2;
                        }
                        else if (randX >= 0 && randX <= 6.75f)
                        {
                            float X2 = Random.Range(-6.75f, -4f);
                            randX2 = randX + X2;
                        }
                        else
                        {
                            randX2 = -randX;
                        }

                        whereToSpawn = new Vector2(randX, transform.position.y);
                        whereToSpawn2 = new Vector2(randX2, transform.position.y);
                        for (i = 0; i < obj.Length; i++)
                        {
                            if (obj[i].tag == "4X")
                            {
                                Instantiate(obj[i], whereToSpawn, Quaternion.identity);
                                Instantiate(obj[i], whereToSpawn2, Quaternion.identity);
                                break;
                            }
                        }
                    }

                    else
                    {
                        whereToSpawn = new Vector2(randX, transform.position.y);
                        for (i = 0; i < obj.Length; i++)
                        {
                            if (obj[i].tag == "4X")
                            {
                                Instantiate(obj[i], whereToSpawn, Quaternion.identity);
                                break;
                            }
                        }
                    }
                }
            }

            else if (randSpawn <= 35.0f)
            {
                randX = Random.Range(-5.55f, 5.55f);
                whereToSpawn = new Vector2(randX, transform.position.y);
                for (i = 0; i < obj.Length; i++)
                {
                    if (obj[i].tag == "Platform")
                    {
                        Instantiate(obj[i], whereToSpawn, Quaternion.identity);
                        break;
                    }
                }
            }

            else if (randSpawn <= 95.0f)
            {
                randX = Random.Range(-7.1f, 7.1f);
                if (rDs)
                {
                    if (randX >= -6.75f && randX < 0f)
                    {
                        float X2 = Random.Range(4, 6.75f);
                        randX2 = randX + X2;
                    }
                    else if (randX >= 0 && randX <= 6.75f)
                    {
                        float X2 = Random.Range(-6.75f, -4f);
                        randX2 = randX + X2;
                    }
                    else
                    {
                        randX2 = -randX;
                    }

                    whereToSpawn = new Vector2(randX, transform.position.y);
                    whereToSpawn2 = new Vector2(randX2, transform.position.y);
                    for (i = 0; i < obj.Length; i++)
                    {
                        if (obj[i].tag == "Triangle")
                        {
                            Instantiate(obj[i], whereToSpawn, Quaternion.identity);
                            Instantiate(obj[i], whereToSpawn2, Quaternion.identity);
                            break;
                        }
                    }
                }

                else
                {
                    whereToSpawn = new Vector2(randX, transform.position.y);
                    for (i = 0; i < obj.Length; i++)
                    {
                        if (obj[i].tag == "Triangle")
                        {
                            Instantiate(obj[i], whereToSpawn, Quaternion.identity);
                            break;
                        }
                    }
                }
            }

            timeBtwSpawn = startTimeBtwSpawn;
            if (startTimeBtwSpawn > 0.5f)
            {
                startTimeBtwSpawn -= 0.02f;
            }
            else if (startTimeBtwSpawn < 0.5f)
            {
                startTimeBtwSpawn = 0.5f;
            }
        }
        else
        {
            timeBtwSpawn -= Time.deltaTime;
        }
    }
}
