using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource[] sounds;

    void Awake()
    {
        App.audioManager = this;
    }

    public void PlaySound(int n)
    {
        if (PlayerPrefs.GetString("Audio")=="true")
        {
            sounds[n].Play();
        }
    }
}
