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

    void Update()
    {
        time += Time.deltaTime;

        if (time > 1)
        {
            Instantiate(bullet, transform.position, Quaternion.identity, App.gameManager.parent);
            time = 0;
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
}
