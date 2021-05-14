using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MenuScreen : ScreenBase
{
    public TMP_Text timeTxt;
    public TMP_Text coinsTxt;

    bool settings = false;
    bool shop = false;

    void Awake()
    {
        App.menuScreen = this;
    }

    public void StartGame() 
    {       
        App.screenManager.Show<InGameScreen>();
        Hide();
        App.gameManager.StartGame();
        App.inGameScreen.UpdateTxt();
        App.screenManager.Hide<SettingsScreen>();
        App.screenManager.Hide<ShopScreen>();
        App.audioManager.PlaySound(4);
        App.gameManager.ResetTime();
    }

    public void QuitGame()
    {
        Application.Quit();
        App.audioManager.PlaySound(4);
    }

    public void ShowSettings()
    {
        App.screenManager.Hide<ShopScreen>();
        App.audioManager.PlaySound(4);
        settings = ! settings;
        if (settings)
        {
            App.screenManager.Show<SettingsScreen>();
        }
        else
        {
            App.screenManager.Hide<SettingsScreen>();
        }

        float t = PlayerPrefs.GetFloat("Time");
        timeTxt.text = ((int)t).ToString() + " seconds played!";
    }

    public void ShowShop()
    {
        App.screenManager.Hide<SettingsScreen>();
        App.audioManager.PlaySound(4);
        shop = !shop;
        if (shop)
        {
            App.screenManager.Show<ShopScreen>();

        }
        else
        {
            App.screenManager.Hide<ShopScreen>();
        }

        coinsTxt.text = PlayerPrefs.GetInt("Coins").ToString();
        App.shopScreen.SetButtons();
    }

    public void UpdateTxt()
    {
        coinsTxt.text = PlayerPrefs.GetInt("Coins").ToString();
    }
}
