using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player : MonoBehaviour
{
    private Rigidbody2D rb;
    public GameObject record;

    public float checkRad;
    public LayerMask whatIsSolid;
    public Transform L;
    private bool left;
    public Transform R;
    private bool right;

    public GameObject deathEffect;

    public float speed = 7.5f;
    private float speedIncrease = 0.095f;
    private float moveInput;
    private bool facingRight;
    private float angle;
    private float angleTemp;

    private float timeBtwTouches;
    public float startTimeBtwTouches;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        moveInput = 0f;
        angleTemp = angle = 3f;
        facingRight = true;
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Coin")
        {
            Destroy(collision.gameObject);
        }
        else
        {
            Death();
        }
    }

    public void Death()
    {
        record.SetActive(true);
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    private void Update()
    {
        if (transform.position.x > 9.25f || transform.position.x < -9.25f)
        {
            Death();
        }
        if (speed <= 50.0f)
        {
            speed += speedIncrease * Time.deltaTime;
            if (angleTemp > 0f)
            {
                angleTemp -= speedIncrease / 14f * Time.deltaTime;
            }
            else if (angleTemp < 0f)
            {
                angleTemp = 0f;
            }
            left = Physics2D.OverlapCircle(L.position, checkRad, whatIsSolid);
            right = Physics2D.OverlapCircle(R.position, checkRad, whatIsSolid);
            if (left || right)
            {
                angle = 0;
                transform.eulerAngles = new Vector3(0f, 0f, angle);
            }
            else
            {
                angle = angleTemp;
                transform.eulerAngles = new Vector3(0f, 0f, moveInput * angle);
            }
        }
        if (timeBtwTouches <= 0f)
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.touchCount > 0)
            {
                //Touch touch = Input.GetTouch(0);
                //if (touch.phase == TouchPhase.Began)
                //{
                    if (facingRight)
                    {
                        moveInput = -1; 
                        facingRight = !facingRight;
                    }
                    else
                    {
                        moveInput = 1;                        
                        facingRight = !facingRight;
                    }
                    transform.eulerAngles = new Vector3(0f, 0f, -moveInput * angle);
                    rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
                    timeBtwTouches = startTimeBtwTouches;
                //}
            }
        }
        else
        {
            timeBtwTouches -= Time.deltaTime;
        }
        
    }
}
