using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    private float speed;
    private float distance;
    public LayerMask whatIsPlayer;
    public LayerMask whatIsWall;
    public LayerMask whatIsEnemy;

    private void Start()
    {
        if (PlayerPrefs.HasKey("SpeedObj"))
        {
            speed = PlayerPrefs.GetFloat("SpeedObj");
        }
        if(speed > 102f)
        {
            speed = 102f;
        }
        else if (speed < 102f)
        {
            speed += 3f;
        }
    }

    private void Update()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.right, distance, whatIsPlayer);
        if (hitInfo.collider != null)
        {
            if (hitInfo.collider.CompareTag("Player"))
            {
                hitInfo.collider.GetComponent<player>().Death();
            }
            Destroy(gameObject);
        }
        hitInfo = Physics2D.Raycast(transform.position, transform.right, distance, whatIsWall);
        if (hitInfo.collider != null)
        {
            Destroy(gameObject);
        }
        hitInfo = Physics2D.Raycast(transform.position, transform.right, distance, whatIsEnemy);
        if (hitInfo.collider != null)
        {
            Destroy(gameObject);
        }
        transform.Translate(Vector2.down * speed * Time.deltaTime);

        if (transform.position.x > 20f || transform.position.x < -20f || transform.position.y > 40f || transform.position.y < -21f)
        {
            Destroy(gameObject);
        }
    }
}
