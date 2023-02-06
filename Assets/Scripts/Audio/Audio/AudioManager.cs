using System;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    [Header("Audio Source")][Tooltip("Place your audio sources here")]
    
    [SerializeField] AudioSource gameMusic;
    [SerializeField] AudioSource gameSound;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider soundSlider;

    
    private void Start()
    {
        if (PlayerPrefs.GetInt("FIRSTTIMEOPENINGAUDIO", 1) == 1)
        {
            PlayerPrefs.SetInt("FIRSTTIMEOPENINGAUDIO", 0);
            musicSlider.value = 0.2f;
            soundSlider.value = 0.8f;
            SaveAudio();
        }
        else
        {
            musicSlider.value = PlayerPrefs.GetFloat("Music");
            soundSlider.value = PlayerPrefs.GetFloat("Sound");
        }
    }

    public void ChangeSound()
    {
        gameSound.volume = soundSlider.value;
        PlayerPrefs.SetFloat("Sound", soundSlider.value);
    }

    public void ChangeMusic()
    {
        gameMusic.volume = musicSlider.value;
        PlayerPrefs.SetFloat("Music", musicSlider.value);
    }

  
    private void SaveAudio()
    {
        PlayerPrefs.SetFloat("Sound", soundSlider.value);
        PlayerPrefs.SetFloat("Music", musicSlider.value);
    }
}


