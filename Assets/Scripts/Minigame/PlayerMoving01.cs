using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoving01 : MonoBehaviour
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
            if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
                {
                    rb2d.velocity = new Vector2(speed, 0);
                }
            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    rb2d.velocity = new Vector2(-speed, 0);
                }
            if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.LeftArrow))
                {
                    rb2d.velocity = new Vector2(0, 0);
                }
            if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.RightArrow))
                {
                    rb2d.velocity = new Vector2(0, 0);
                }

            //position check
            if (transform.position.x > 8.41)
            {
                rb2d.velocity = new Vector2(0, 0);
                transform.position = new Vector2(8.4f, -2f);
            }
            if (transform.position.x < -8.41)
            {
                rb2d.velocity = new Vector2(0, 0);
                transform.position = new Vector2(-8.4f, -2f);
            }

        }
    }

    private void OnDisable()
    {
        transform.position = new Vector2(0, -2f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Pickup_water")
        {
            Game.Control.Score_water += 1;
            Destroy(collision.gameObject);
        }
    }
}
