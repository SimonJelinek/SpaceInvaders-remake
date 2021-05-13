using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerBehavior : MonoBehaviour
{
    public GameObject bullet;
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    public Vector3 offset;
    public float speed;
    float xPos;

    public int hp=3;

    void Awake() 
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        App.playerBehavior = this;

        if (PlayerPrefs.GetString("Skin")=="green")
        {
            sr.sprite = App.gameManager.skins[0];
        }
        if (PlayerPrefs.GetString("Skin") == "blue")
        {
            sr.sprite = App.gameManager.skins[1];
        }
        if (PlayerPrefs.GetString("Skin") == "orange")
        {
            sr.sprite = App.gameManager.skins[2];
        }
        if (PlayerPrefs.GetString("Skin") == "red")
        { 
            sr.sprite = App.gameManager.skins[3];
        }
    }

    void Update()
    {
        xPos = CrossPlatformInputManager.GetAxis("Horizontal");
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
        App.audioManager.PlaySound(0);
    }
}
