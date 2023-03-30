using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSettings : MonoBehaviour
{
    [SerializeField] private AudioMixer myMixer;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider sfxSlider;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("musicSaved"))
        {
            musicSlider.value = PlayerPrefs.GetFloat("musicSaved");
        }
        else
        {
            PlayerPrefs.SetFloat("musicSaved", musicSlider.value);
        }

        if (PlayerPrefs.HasKey("sfxSaved"))
        {
            sfxSlider.value = PlayerPrefs.GetFloat("sfxSaved");
        }
        else
        {
            PlayerPrefs.SetFloat("sfxSaved", sfxSlider.value);
        }

        SetMusicVolume();
        gameObject.GetComponent<AudioSource>().Play();
    }

    public void SetMusicVolume()
    {
        float musicVolume = musicSlider.value;
        
        myMixer.SetFloat("music", Mathf.Log10(musicVolume) * 20);
        
        gameObject.GetComponent<SaveAudioVolume>().SaveMusicVolume(musicVolume);
    }

    public void SetSFXVolume()
    {
        float sfxVolume = sfxSlider.value;
        myMixer.SetFloat("sfx", Mathf.Log10(sfxVolume) * 20);
        gameObject.GetComponent<SaveAudioVolume>().SaveSFXVolume(sfxVolume);
    }
}
