using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScreen : ScreenBase
{
    bool settings = false;

    public void StartGame() 
    {       
        App.screenManager.Show<InGameScreen>();
        Hide();
        App.gameManager.StartGame();
        App.inGameScreen.UpdateTxt();
        App.screenManager.Hide<SettingsScreen>();
        App.audioManager.PlaySound(4);
    }

    public void QuitGame()
    {
        Application.Quit();
        App.audioManager.PlaySound(4);
    }

    public void ShowSettings()
    {
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
    }
}
