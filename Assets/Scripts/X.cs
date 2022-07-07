using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class X : MonoBehaviour
{
    public GameObject bullet;
    public Transform[] shotPoint;
    private HingeJoint2D hinge;
    private float speed = 12.0f;
    private float timeBtwShots = 1.0f;
    public float startTimeBtwShots = 3.0f;

    private void Start()
    {
        if (PlayerPrefs.HasKey("SpeedObj"))
        {
            speed = PlayerPrefs.GetFloat("SpeedObj");
            if (speed > 44f)
            {
                timeBtwShots = 0.22f;
            }
            else if (speed > 88f)
            {
                timeBtwShots = 0.05f;
            }
        }
        hinge = GetComponent<HingeJoint2D>();
        var motor = hinge.motor;
        motor.motorSpeed = speed * 4f;
        hinge.motor = motor;
    }

    private void Update()
    {
        if (timeBtwShots <= 0f)
        {
            Instantiate(bullet, shotPoint[0].position, shotPoint[0].rotation);
            Instantiate(bullet, shotPoint[1].position, shotPoint[1].rotation);
            Instantiate(bullet, shotPoint[2].position, shotPoint[2].rotation);
            Instantiate(bullet, shotPoint[3].position, shotPoint[3].rotation);
            timeBtwShots = startTimeBtwShots;
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
    }
}