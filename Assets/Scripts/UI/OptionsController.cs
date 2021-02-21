using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class OptionsController : MonoBehaviour
{
    [SerializeField] Slider volumeSlider; 
    [SerializeField] Slider difficultySlider;

    [SerializeField] float deffaultVolume = 0.6f;
    [SerializeField] float deffaultDifficulty = 0f;
    
    void Start()
    {
        volumeSlider.value = PlayerPrefsController.GetMasterVolume();
        difficultySlider.value = PlayerPrefsController.GetDifficulty();
    }

    void Update()
    {
        var musicPlayer = FindObjectOfType<MusicPlayer>();
        musicPlayer?.SetVolume(volumeSlider.value);
    }

    public void Deffault()
    {
        difficultySlider.value = deffaultDifficulty;
        volumeSlider.value = deffaultVolume;
    }

    public void Save()
    {
        PlayerPrefsController.SetDifficulty(difficultySlider.value);
        PlayerPrefsController.SetMasterVolume(volumeSlider.value);
    }
}
