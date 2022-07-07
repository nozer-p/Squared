using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class dead : MonoBehaviour
{
    public GameObject scoreObj;
    public int score;
    public Text scoreDisplay;

    public static dead instance;

    public int best = 55;
    public Text bestDisplay;
    private scoreManager scoreGame;
    public bool life;


    private void Awake()
    {
        instance = this;
        if (PlayerPrefs.HasKey("SaveScore"))
        {
            best = PlayerPrefs.GetInt("SaveScore");
        }
    }
    private void Start()
    {
        scoreGame = FindObjectOfType<scoreManager>();
        score = scoreGame.score;
        scoreDisplay.text = score.ToString();
        Best();
        bestDisplay.text = best.ToString();
        scoreObj.SetActive(false);
    }

    private void Best()
    {
        if (best < score)
        {
            best = score;
            PlayerPrefs.SetInt("SaveScore", best);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.touchCount > 0)
        {
            //Touch touch = Input.GetTouch(0);
            //if (touch.phase == TouchPhase.Began)
            //{
            PlayerPrefs.SetFloat("SpeedObj", 12.0f);
            SceneManager.LoadScene(1);
            //}
        }
    }
}
