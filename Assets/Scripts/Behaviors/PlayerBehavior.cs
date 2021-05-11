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
}
