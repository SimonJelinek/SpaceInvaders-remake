using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    private Rigidbody2D rb;
    public Vector3 dir;
    public float speed;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start() 
    {
        rb.velocity = dir*speed;
    }

    void Update() 
    {
        if (transform.position.y >= 5.3f) 
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }
    }
}
