using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    public GameObject bullet;
    private Rigidbody2D rb;

    public Vector3 offset;
    public float speed;
    float xPos;

    int hp=3;

    void Awake() 
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        xPos = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            Instantiate(bullet,transform.position+offset, Quaternion.identity, App.gameManager.parent);
        }
    }

    void FixedUpdate() 
    {
        rb.velocity = new Vector3(xPos*speed,0,0);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "EnemyBullet")
        {
            HitByBullet(1);
        }
    }

    void HitByBullet(int c)
    {
        hp -= c;
        if (hp == 0)
        {
            App.gameManager.GameOver();
        }
    }
}
