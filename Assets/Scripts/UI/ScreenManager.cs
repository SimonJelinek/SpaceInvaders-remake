using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenManager : MonoBehaviour
{
    private ScreenBase[] screens;

    void Awake() 
    {
        screens = GetComponentsInChildren<ScreenBase>(true);
        App.screenManager = this;
    }

    public void Show<T>() {

        for (int i = 0; i < screens.Length; i++) 
        {
            if (screens[i].GetType() == typeof(T)) {
                screens[i].Show();
            }
        }
    }


    public void Hide<T>() {

        for (int i = 0; i < screens.Length; i++) 
        {
            if (screens[i].GetType() == typeof(T)) {
                screens[i].Hide();
            }
        }
    }
}
