using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PindahScene : MonoBehaviour
{
    public bool isEscapeToExit;

    AudioSource audioData;
    // Start is called before the first frame update
    void Start()
    {
        audioData = GetComponent<AudioSource>();
        audioData.Play(0);
        audioData.loop = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (isEscapeToExit)
            {
                Application.Quit();
            }
            else
            {
                ChapterPermainan();
            }
        }
    }

    public void MulaiPermainan()
    {
        SceneManager.LoadScene("Chapter_1");
    }

    public void SettingPermainan()
    {
        SceneManager.LoadScene("Setting");
    }

    public void AudioSetting()
    {
        SceneManager.LoadScene("Audio");
    }

    public void ChapterPermainan()
    {
        SceneManager.LoadScene("Unlock Chapter");
    }

    public void KembaliKeMenu()
    {
        SceneManager.LoadScene("Menu");
    }

     public void ResolutionSetting()
    {
        SceneManager.LoadScene("Resolution");
    }
}
