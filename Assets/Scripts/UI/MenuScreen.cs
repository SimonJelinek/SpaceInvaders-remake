using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MenuScreen : ScreenBase
{
    public TMP_Text timeTxt;

    bool settings = false;

    public void StartGame() 
    {       
        App.screenManager.Show<InGameScreen>();
        Hide();
        App.gameManager.StartGame();
        App.inGameScreen.UpdateTxt();
        App.screenManager.Hide<SettingsScreen>();
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

        float t = Mathf.Ceil(PlayerPrefs.GetFloat("Time"));
        t = t / 60;
        timeTxt.text = ((int)t).ToString() + " minutes played!";
    }
}
