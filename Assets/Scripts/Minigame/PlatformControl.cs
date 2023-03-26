using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformControl : MonoBehaviour
{

    public int toTheRight = 1;
    float randomIndex;
    Rigidbody2D rb2d;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        randomIndex = Random.Range(0.75f, 1.25f);
    }

    // Update is called once per frame
    void Update()
    {
        rb2d.velocity = new Vector2(5.0f * toTheRight * randomIndex, 0);
    }
}
