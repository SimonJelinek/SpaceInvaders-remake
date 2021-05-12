using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InGameScreen : ScreenBase
{
    public TMP_Text hpTxt;

    void Awake()
    {
        App.inGameScreen = this;
    }

    void Start()
    {
        UpdateTxt();
    }

    public void UpdateTxt()
    {
        hpTxt.text = App.playerBehavior.hp.ToString();
    }

    public void OnShootClick()
    {
        App.playerBehavior.Shoot();
    }
}
