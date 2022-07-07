using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreManager : MonoBehaviour
{
    public int score;
    public Text scoreDisplay;
    private float timeBtw = 0.5f;
    private float startTimeBtw = 1f;

    private void Start()
    {
        scoreDisplay.text = "0";
    }

    private void Update()
    {
        if (timeBtw <= 0f)
        {
            score += 1;
            scoreDisplay.text = score.ToString();
            timeBtw = startTimeBtw;
            if (startTimeBtw > 0.2f)
            {
                startTimeBtw -= 0.002f;
            }
            else if (startTimeBtw < 0.2f)
            {
                startTimeBtw = 0.2f;
            }
        }
        else
        {
            timeBtw -= Time.deltaTime;
        }
    }
}
