using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopScreen : ScreenBase
{
    public GameObject coinsObj;
    public Button[] skinButtons;
    public Button buyButton;

    void Awake()
    {
        App.shopScreen = this;
    }

    public void SetButtons()
    {
        SetB();
    }

    public void BuyButton()
    {
        PlayerPrefs.SetString("Skins", "unlocked");
        PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") - 10000);
        App.menuScreen.UpdateTxt();
        SetB();
    }

    void SetB()
    {
        int coins = PlayerPrefs.GetInt("Coins");
            if (coins >= 10000)
            {
                buyButton.interactable = true;
            }
            else
            {
                buyButton.interactable = false;
            }
        

        if (PlayerPrefs.GetString("Skins") == "unlocked")
        {
            foreach (Button b in skinButtons)
            {
                b.interactable = true;
            }
            coinsObj.SetActive(false);
        }
        else
        {
            foreach (Button b in skinButtons)
            {
                b.interactable = false;
            }
            coinsObj.SetActive(true);
        }
    }

    public void SelectSkin(int c)
    {
        if (c==0)
        {
            Debug.Log("Green");
        }
        if (c==1)
        {
            Debug.Log("Blue");
        }
        if (c==2)
        {
            Debug.Log("Orange");
        }
        if (c==3)
        {
            Debug.Log("Red");
        }
    }
}
