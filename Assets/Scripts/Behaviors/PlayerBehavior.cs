using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    private Rigidbody2D rb;

    public float speed;
    float xPos;

    void Awake() 
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        xPos = Input.GetAxis("Horizontal");
    }

    void FixedUpdate() 
    {
        rb.velocity = new Vector3(xPos*speed,0,0);
    }
}
