using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverScreen : ScreenBase
{
    public void RestartGame()
    {
        App.screenManager.Show<InGameScreen>();
        App.gameManager.StartGame();
        Hide();
    }
  
    public void ReturnToMenu()
    {
        App.screenManager.Show<MenuScreen>();
        Hide();
    }
}
