﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverScreen : ScreenBase
{
    public void RestartGame()
    {
        App.screenManager.Show<InGameScreen>();
        App.gameManager.StartGame();
        Hide();
        App.gameManager.ResetEnemiesAlive();
        App.inGameScreen.UpdateTxt();
        App.audioManager.PlaySound(4);
    }

    public void ReturnToMenu()
    {
        App.screenManager.Show<MenuScreen>();
        Hide();
        App.gameManager.ResetEnemiesAlive();
        App.inGameScreen.UpdateTxt();
        App.audioManager.PlaySound(4);
    }
}
