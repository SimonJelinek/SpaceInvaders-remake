using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    public GameObject enemies;
    public GameObject border;
    public GameObject obstacle;
    public Transform parent;

    public TMP_Text gameoverCoinsTxt;
    public TMP_Text winCoinsTxt;
    public Sprite[] skins;

    int goCoins;
    int winCoins;
    int enemiesAlive = 64;

    void Awake() 
    {
        App.gameManager = this;
    }

    void Start() 
    {
        App.screenManager.Show<MenuScreen>();
        App.screenManager.Hide<InGameScreen>();
        App.screenManager.Hide<GameOverScreen>();
        App.screenManager.Hide<WinScreen>();
        App.screenManager.Hide<SettingsScreen>();
        App.screenManager.Hide<ShopScreen>();
        
        PlayerPrefs.SetString("Skins", "locked");        
        PlayerPrefs.SetInt("Coins", 0);
        //PlayerPrefs.SetInt("Coins", 10000);
        PlayerPrefs.SetString("Skin", "a");
        //PlayerPrefs.SetFloat("Time", 0);
        PlayerPrefs.SetString("Skin", "m");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F12))
        {
            PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") + 9999);
        }
    }

    public void StartGame() 
    {
        Instantiate(player, new Vector3(0, -3.2f, 0), Quaternion.identity, parent);
        Instantiate(border, new Vector3(), Quaternion.identity, parent);
        Instantiate(obstacle, new Vector3(-1.5f, -2.65f, 0), Quaternion.identity, parent);
        Instantiate(obstacle, new Vector3(1.5f, -2.65f, 0), Quaternion.identity, parent);
        InstantiateEnemies();
    }

    public void ReturnToMenu() 
    {
        foreach (Transform child in parent) 
        {
            Destroy(child.gameObject);
        }
    }

    void InstantiateEnemies()
    {
        Instantiate(enemies, new Vector3(), Quaternion.identity, parent);
    }

    public void KillEnemy()
    {
        enemiesAlive -= 1;
        if (enemiesAlive <= 0)
        {
            Win();
        }
    }

    public void Win()
    {
        App.screenManager.Show<WinScreen>();
        App.screenManager.Hide<InGameScreen>();
        App.audioManager.PlaySound(5);
        ReturnToMenu();
        CalculatePrize(true);
        winCoinsTxt.text = winCoins.ToString();
    }

    public void GameOver()
    {
        App.screenManager.Show<GameOverScreen>();
        App.screenManager.Hide<InGameScreen>();
        ReturnToMenu();
        App.audioManager.PlaySound(1);
        PlayerPrefs.SetFloat("Time", PlayerPrefs.GetFloat("Time") + App.inGameScreen.time);
        CalculatePrize(false);
        gameoverCoinsTxt.text = goCoins.ToString();
    }

    public void ResetEnemiesAlive()
    {
        enemiesAlive = 64;
    }

    public void ResetTime()
    {
        App.inGameScreen.time = 0;
        App.inGameScreen.t = 0;
    }

    void CalculatePrize(bool win)
    {
        float time = PlayerPrefs.GetFloat("Time");
        int t = (int)time;
        int c = PlayerPrefs.GetInt("Coins");
        int p = App.inGameScreen.time;

        if (win)
        {
            if (p < 40)
            {
                PlayerPrefs.SetInt("Coins", c + 500);
                winCoins = 500;
            }
            else if (p < 45)
            {
                PlayerPrefs.SetInt("Coins", c + 450);
                winCoins = 450;
            }
            else if (p < 50)
            {
                PlayerPrefs.SetInt("Coins", c + 400);
                winCoins = 400;
            }
            else if (p < 55)
            {
                PlayerPrefs.SetInt("Coins", c + 350);
                winCoins = 350;
            }
            else if (p < 60)
            {
                PlayerPrefs.SetInt("Coins", c + 300);
                winCoins = 300;
            }
            else
            {
                PlayerPrefs.SetInt("Coins", c + 50);
                winCoins = 50;
            }
        }
        else
        {
            PlayerPrefs.SetInt("Coins", t*0 + c);
            goCoins = t * 0;
        }
    }
}
