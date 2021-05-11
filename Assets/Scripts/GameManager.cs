using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject player;
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
    }

    public void ReturnToMenu() 
    {
        foreach (Transform child in parent) 
        {
            Destroy(child.gameObject);
        }
    }
}
