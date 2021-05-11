using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public GameObject bullet;

    int dir = -1;
    public float maxL;
    public float maxR;
    public float speed;
    float time = 0;

    int spawnTime;
    int hp = 2;

    void Start()
    {
        spawnTime = SpawnTime();
    }

    void Update()
    {
        time += Time.deltaTime;

        if (time > spawnTime)
        {
            Instantiate(bullet, transform.position, Quaternion.identity, App.gameManager.parent);
            time = 0;
            spawnTime = SpawnTime();
        }
    }

    void FixedUpdate()
    { 
        if (transform.position.x >= maxL)
        {
            dir *= -1;
        }

        if (transform.position.x <= maxR)
        {
            dir *= -1;
        }

        transform.position += new Vector3(dir*speed,0,0);
    }

    int SpawnTime()
    {
        return Random.Range(1, 40);
    }

    void HitByBullet(int c)
    {
        hp -= c;
        if (hp <= 0)
        {
            Destroy(gameObject);
            App.gameManager.KillEnemy();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            HitByBullet(1);
        }
    }
}
