using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platform : MonoBehaviour
{
    private HingeJoint2D hinge;
    private float speed;

    private void Start()
    {
        hinge = GetComponent<HingeJoint2D>();
        var motor = hinge.motor;
        speed = motor.motorSpeed * Time.time / 10;
        if (speed <= 50.0f)
        {
            speed = 50.0f;
        }
        else if (speed > 400.0f)
        {
            speed = 400.0f;
        }
        motor.motorSpeed = speed;
        hinge.motor = motor;
    }
}
