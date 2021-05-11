using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemy: MonoBehaviour
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
        rb.velocity = dir * speed;
    }

    void Update()
    {
        if (transform.position.y <= -5)
        {
            Destroy(gameObject);
        }
    }

}
