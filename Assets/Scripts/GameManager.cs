using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    public GameObject enemies;
    public GameObject border;
    public GameObject obstacle;
    public Transform parent;

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
        ReturnToMenu();
    }

    public void GameOver()
    {
        App.screenManager.Show<GameOverScreen>();
        App.screenManager.Hide<InGameScreen>();
        ReturnToMenu();
        App.audioManager.PlaySound(1);
    }

    public void ResetEnemiesAlive()
    {
        enemiesAlive = 64;
    }
}
