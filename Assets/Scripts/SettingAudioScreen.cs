using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SettingAudioScreen : MonoBehaviour
{
    public AudioMixer audioMixer;
    // public Slider musicSlider;

    // Start is called before the first frame update
    void Start()
    {
        // SetVolume(PlayerPrefs.GetFloat("musicVolume", 0));

        // musicSlider.value = PlayerPrefs.GetFloat("musicVolume", 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetVolume (float volume)
    {
        audioMixer.SetFloat("volume", volume);

        // PlayerPrefs.SetFloat("musicVolume", volume);
        // PlayerPrefs.Save();
    }

    public void Mute()
    {
        AudioListener.pause = !AudioListener.pause;
    }
}
