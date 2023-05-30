using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeControl : MonoBehaviour
{
    public string[] volumeParameters = new []{"MasterVolume"};
    public AudioMixer mixer;
    public Slider slider;
    private float _volumeValue;
    private const float _multiplier = 20f;

    private void Awake()
    {
        slider.onValueChanged.AddListener(HandleSliderValueChanged);
    }

    private void HandleSliderValueChanged(float value)
    {
        _volumeValue = Mathf.Log10(value) * _multiplier;
        foreach (var sound in volumeParameters)
        {
            mixer.SetFloat(sound, _volumeValue);
        }
    }

    void Start()
    {
        foreach (var sound in volumeParameters)
        {
            _volumeValue = PlayerPrefs.GetFloat(sound, Mathf.Log10(slider.value) * _multiplier);
        }
        slider.value = Mathf.Pow(10f, _volumeValue / _multiplier);
    }

    private void OnDisable()
    {
        foreach (var sound in volumeParameters)
        {
            PlayerPrefs.SetFloat(sound, _volumeValue);
        }
    }
}
