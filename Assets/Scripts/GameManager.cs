using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    public GameObject enemies;
    public GameObject border;
    public Transform parent;

    int enemiesAlive = 72;

    void Awake() 
    {
        App.gameManager = this;
    }

    void Update()
    {
        Debug.Log(enemiesAlive);
    }

    void Start() 
    {
        App.screenManager.Show<MenuScreen>();
        App.screenManager.Hide<InGameScreen>();
        App.screenManager.Hide<GameOverScreen>();
        App.screenManager.Hide<WinScreen>();
    }

    public void StartGame() 
    {
        Instantiate(player, new Vector3(0,-4.25f, 0), Quaternion.identity, parent);
        Instantiate(border, new Vector3(), Quaternion.identity, parent);
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
    }

    public void ResetEnemiesAlive()
    {
        enemiesAlive = 72;
    }
}
