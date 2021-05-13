using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopScreen : ScreenBase
{
    public GameObject coinsObj;
    public GameObject skinsObj;
    public Button[] skinButtons;
    public Button buyButton;
    public Sprite[] skins;
    public Image image;

    void Awake()
    {
        App.shopScreen = this;
    }

    public void SetButtons()
    {
        SetB();
        ShowCurrentSkin();
        if (PlayerPrefs.GetString("Skins")=="unlocked")
        {
            skinsObj.SetActive(true);
            if (PlayerPrefs.GetString("Skin")=="green")
            {
                image.sprite = skins[0];
            }
            if (PlayerPrefs.GetString("Skin") == "blue")
            {
                image.sprite = skins[1];
            }
            if (PlayerPrefs.GetString("Skin") == "orange")
            {
                image.sprite = skins[2];
            }
            if (PlayerPrefs.GetString("Skin") == "red")
            {
                image.sprite = skins[3];
            }
        }
        else
        {
            skinsObj.SetActive(false);
        }
    }

    public void BuyButton()
    {
        PlayerPrefs.SetString("Skins", "unlocked");
        PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") - 10000);
        PlayerPrefs.SetString("Skins", "green");
        App.menuScreen.UpdateTxt();
        SetButtons();
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
            PlayerPrefs.SetString("Skin", "green");
            image.sprite = skins[0];

        }
        if (c==1)
        {
            PlayerPrefs.SetString("Skin", "blue");
            image.sprite = skins[1];
        }
        if (c==2)
        {
            PlayerPrefs.SetString("Skin", "orange");
            image.sprite = skins[2];
        }
        if (c==3)
        {
            PlayerPrefs.SetString("Skin", "red");
            image.sprite = skins[3];
        }
        ShowCurrentSkin();
    }

    public void ShowCurrentSkin()
    {
        string skin = PlayerPrefs.GetString("Skin");
        if (skin=="green")
        {
            Debug.Log("Green");
        }
        if (skin == "blue")
        {
            Debug.Log("blue");
        }
        if (skin == "orange")
        {
            Debug.Log("orange");
        }
        if (skin == "red")
        {
            Debug.Log("red");
        }
    }
}
