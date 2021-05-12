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

    public int hp=3;

    void Awake() 
    {
        rb = GetComponent<Rigidbody2D>();
        App.playerBehavior = this;
    }

    void Update()
    {
        xPos = Input.GetAxis("Horizontal");
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
        App.inGameScreen.UpdateTxt();
        if (hp == 0)
        {
            App.gameManager.GameOver();
        }
    }

    public void Shoot()
    {
        Instantiate(bullet, transform.position + offset, Quaternion.identity, App.gameManager.parent); 
    }
}
