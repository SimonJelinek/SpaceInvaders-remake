using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
    }

    public void StartGame() 
    {
        Instantiate(player, new Vector3(0, -3.43f, 0), Quaternion.identity, parent);
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
        Debug.Log(App.inGameScreen.time);
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

        if (win)
        {
            if (time < 60)
            {
                PlayerPrefs.SetInt("Coins", t*2 + (c));
                winCoins = t * 2;
            }
            else
            {
                PlayerPrefs.SetInt("Coins", t + c);
                winCoins = t;
            }
        }
        else
        {
            PlayerPrefs.SetInt("Coins", t*0 + c);
            goCoins = t * 0;
        }
    }
}
