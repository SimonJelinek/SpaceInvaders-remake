﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameScreen : ScreenBase
{
    public void ReturnToMenu() 
    {
        App.screenManager.Show<MenuScreen>();
        Hide();
        App.gameManager.ReturnToMenu();
    }
}
