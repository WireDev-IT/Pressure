using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    private List<string> resolutionStrings;
    private Resolution[] resolutions;
    public TMP_Dropdown resolutionDropdown;
    public Slider fxVolumeSlider;
    public Slider musicVolumeSlider;
    public Toggle fullscreenToggle;
    public TMP_Dropdown graphicsDropdown;

    private void Start()
    {
        int width = PlayerPrefs.GetInt("width", Screen.currentResolution.width);
        int height = PlayerPrefs.GetInt("height", Screen.currentResolution.height);
        Screen.SetResolution(width, height, Screen.fullScreen);

        SetResolutions();
        resolutionDropdown.ClearOptions();
        resolutionDropdown.AddOptions(resolutionStrings);
        resolutionDropdown.value = resolutionStrings.IndexOf(width + " x " + height);
        resolutionDropdown.RefreshShownValue();

        fxVolumeSlider.value = PlayerPrefs.GetFloat("fx", 0);
        musicVolumeSlider.value = PlayerPrefs.GetFloat("music", 0);
        fullscreenToggle.isOn = Convert.ToBoolean(PlayerPrefs.GetString("fullscreen", true.ToString()));
        graphicsDropdown.value = PlayerPrefs.GetInt("quality", 2);
        graphicsDropdown.RefreshShownValue();
    }

    private void SetResolutions()
    {
        resolutions = Screen.resolutions;
        resolutionStrings = new();
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            resolutionStrings.Add(option);
        }
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution r = resolutions[resolutionIndex];
        PlayerPrefs.SetInt("width", r.width);
        PlayerPrefs.SetInt("height", r.height);
        PlayerPrefs.Save();
        Screen.SetResolution(r.width, r.height, Screen.fullScreen);
    }

    public void SetFxVolume(float volume)
    {
        audioMixer.SetFloat("SoundFxVolume", volume);
        PlayerPrefs.SetFloat("fx", volume);
        PlayerPrefs.Save();
    }

    public void SetMusicVolume(float volume)
    {
        audioMixer.SetFloat("MusicVolume", volume);
        PlayerPrefs.SetFloat("music", volume);
        PlayerPrefs.Save();
    }

    public void SetQuality(int index)
    {
        QualitySettings.SetQualityLevel(index);
        PlayerPrefs.SetInt("quality", index);
        PlayerPrefs.Save();
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
        PlayerPrefs.SetString("fullscreen", isFullscreen.ToString());
        PlayerPrefs.Save();
    }

    public void RestoreSettings()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();
        Start();
    }
}