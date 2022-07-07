using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particleControl : MonoBehaviour
{
    private ParticleSystem partSys;
    private float speed;
    private float speedIncrease;

    private void Start()
    {
        partSys = GetComponent<ParticleSystem>();
        var main = partSys.main;
        speed = main.simulationSpeed;
        speedIncrease = 0.01f;
    }

    private void Update()
    {
        if (speed <= 3.6f)
        {
            speed += speedIncrease * Time.deltaTime;
            var main = partSys.main;
            main.simulationSpeed = speed;
        }
    }
}
