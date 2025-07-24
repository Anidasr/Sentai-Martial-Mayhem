using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;

public class Audio : MonoBehaviour
{
    [SerializeField]
    private AudioMixer Mixer;

    [SerializeField]
    private TextMeshProUGUI ValueTextMusic;

    [SerializeField]
    private TextMeshProUGUI ValueTextSFX;

    [SerializeField]
    private Slider volumeMusicSlider;

    [SerializeField]
    private Slider volumeSFXSlider;

    private void Awake()
    {
        if (PlayerPrefs.HasKey("MusicVolume"))
        {
            LoadMusicVolume();
        }
        else
        {
            SetMusicVolume();
        }


        if (PlayerPrefs.HasKey("SfxVolume"))
        {
            LoadSFXVolume();
        }
        else
        {
            SetSFXVolume();
        }

    }

    public void SetMusicVolume()
    {
        float value = volumeMusicSlider.value;
        ValueTextMusic.SetText($"{value.ToString("N1")}");
        Mixer.SetFloat("MusicVolume", Mathf.Log10(value) * 20);
        PlayerPrefs.SetFloat("MusicVolume", value);
    }

    public void SetSFXVolume()
    {
        float value = volumeSFXSlider.value;
        ValueTextSFX.SetText($"{value.ToString("N1")}");
        Mixer.SetFloat("SfxVolume", Mathf.Log10(value) * 20);
        PlayerPrefs.SetFloat("SfxVolume", value);
    }

    public void LoadMusicVolume()
    {
        volumeMusicSlider.value = PlayerPrefs.GetFloat("MusicVolume");
        ValueTextSFX.SetText($"{volumeMusicSlider.value.ToString("N1")}");

        SetMusicVolume();
    }

    public void LoadSFXVolume()
    {
        volumeSFXSlider.value = PlayerPrefs.GetFloat("SfxVolume");
        ValueTextSFX.SetText($"{volumeSFXSlider.value.ToString("N1")}");

        SetMusicVolume();
    }

}
