using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveObj : MonoBehaviour
{
    private float speed = 12.0f;
    private float speedIncrease = 0.25f;

    private void Start()
    {
        if (PlayerPrefs.HasKey("SpeedObj"))
        {
            speed = PlayerPrefs.GetFloat("SpeedObj");
        }
        if (speed > 99.0f)
        {
            speed = 99.0f;
        }
        else if (speed < 99.0f)
        {
            speed += speedIncrease;
            PlayerPrefs.SetFloat("SpeedObj", speed);
        }
    }

    void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);

        if (transform.position.x > 20f || transform.position.x < -20f || transform.position.y > 40f || transform.position.y < -40f)
        {
            Destroy(gameObject);
        }
    }
}
