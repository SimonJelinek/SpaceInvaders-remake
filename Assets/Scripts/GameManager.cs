using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    public GameObject enemies;
    public Transform parent;

    void Awake() 
    {
        App.gameManager = this;
    }

    void Start() 
    {
        App.screenManager.Show<MenuScreen>();
        App.screenManager.Hide<InGameScreen>();
    }

    public void StartGame() 
    {
        Instantiate(player, new Vector3(0,-4.25f, 0), Quaternion.identity, parent);
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
}
