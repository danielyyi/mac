using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public AudioSource music;
    public AudioMixer SFXaudioMixer;
    public AudioMixer musicAudioMixer;
    
    public GameObject settingsMenu;

    public Slider sensSlider;
    public Slider sfxSlider;
    public Slider musicSlider;

    public void Start()
    {
        music.time = PlayerPrefs.GetFloat("AudioTime", 0);
        sensSlider.value = PlayerPrefs.GetFloat("LookSens", 1.75f);
        sfxSlider.value = PlayerPrefs.GetFloat("SFXVolume", 1f);
        musicSlider.value = PlayerPrefs.GetFloat("MusicVolume", 1f);
        PlayerCameraController.lookSensitivity = PlayerPrefs.GetFloat("LookSens", 1.75f);
    }

    void Update()
    {
        PlayerPrefs.SetFloat("AudioTime", music.time);
    }

    public void SetSFXVolume(float volume)
    {
        SFXaudioMixer.SetFloat("SFXVolume", Mathf.Log10(volume) * 40);
        PlayerPrefs.SetFloat("SFXVolume", volume);
    }

    public void SetMusicVolume(float volume)
    {
        musicAudioMixer.SetFloat("MusicVolume", Mathf.Log10(volume) * 40);
        PlayerPrefs.SetFloat("MusicVolume", volume);
    }

    public void SetSensitivity(float sens)
    {
        PlayerCameraController.lookSensitivity = (float)sens;
        PlayerPrefs.SetFloat("LookSens", (float)sens);
    }

    public void Exit()
    {
        settingsMenu.SetActive(false);
    }
}
