using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InGameScreen : ScreenBase
{
    public TMP_Text hpTxt;
    public TMP_Text timeTxt;
    public int time;
    public float t;

    void Awake()
    {
        App.inGameScreen = this;
    }

    void Start()
    {
        UpdateTxt();
    }

    void Update()
    {
        t += Time.deltaTime;
        time = (int)t;
        timeTxt.text = time.ToString(); 
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
