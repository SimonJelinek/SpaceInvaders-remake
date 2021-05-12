using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsScreen : ScreenBase
{
    public Sprite[] icons;
    public Button btn;
    bool on = true;

    void Start()
    {
        if (PlayerPrefs.GetString("Audio")=="false")
        {
            btn.image.sprite = icons[1];
        }
        else
        {
            btn.image.sprite = icons[0];
        }
    }

    public void setSound()
    {
        on = !on;
        if (on)
        {
            btn.image.sprite = icons[1];
            PlayerPrefs.SetString("Audio", "false");
        }
        else
        {
            PlayerPrefs.SetString("Audio", "true");
            btn.image.sprite = icons[0];
        }
    }
}
