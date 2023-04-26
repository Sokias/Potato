using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoving02 : MonoBehaviour
{
    Rigidbody2D rb2d;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Game.Control.canControl)
        {
            //Move
            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                rb2d.velocity = new Vector2(speed, 0);
            }
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                rb2d.velocity = new Vector2(-speed, 0);
            }
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            {
                rb2d.velocity = new Vector2(0, speed);
            }
            if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            {
                rb2d.velocity = new Vector2(0, -speed);
            }
            if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.LeftArrow))
            {
                rb2d.velocity = new Vector2(0, 0);
            }
            if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.RightArrow))
            {
                rb2d.velocity = new Vector2(0, 0);
            }
            if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.UpArrow))
            {
                rb2d.velocity = new Vector2(0, 0);
            }
            if (Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.DownArrow))
            {
                rb2d.velocity = new Vector2(0, 0);
            }

            //position check
            if (transform.position.x > 6.51)
            {
                rb2d.velocity = new Vector2(0, 0);
                transform.position = new Vector2(6.5f, transform.position.y);
            }
            if (transform.position.x < -6.51)
            {
                rb2d.velocity = new Vector2(0, 0);
                transform.position = new Vector2(-6.5f, transform.position.y);
            }
            if (transform.position.y > 2.01)
            {
                rb2d.velocity = new Vector2(0, 0);
                transform.position = new Vector2(transform.position.x, 2f);
            }
            if (transform.position.y < -3.01)
            {
                rb2d.velocity = new Vector2(0, 0);
                transform.position = new Vector2(transform.position.x, -3f);
            }

        }
    }

    private void OnDisable()
    {
        transform.position = new Vector2(0, -2f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Pickup_bugs")
        {
            Game.Control.Score_health -= 1;
            Destroy(collision.gameObject);
        }
    }
}
