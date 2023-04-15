using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup_bugs_control : MonoBehaviour
{
    Transform player; 
    public float moveSpeed;
    float timer = 0f;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("potato3").transform;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer < 1f)
        {
            transform.up = player.position - transform.position;
        }
        if (timer > 10f) { Destroy(this.gameObject); }
        transform.position += transform.up * moveSpeed * Time.deltaTime;
    }
}
