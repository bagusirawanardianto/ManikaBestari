using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PindahScene : MonoBehaviour
{
    public bool isEscapeToExit;
    public string cond;

    AudioSource audioData;
    // Start is called before the first frame update
    void Start()
    {
        audioData = GetComponent<AudioSource>();
        audioData.Play(0);
        audioData.loop = true;

        cond = PlayerPrefs.GetString("isPlayed", "false");
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

        if (cond.Equals("false"))
        {
            SceneManager.LoadScene("Intro");
        }
        else
        {
            SceneManager.LoadScene("Unlock Chapter");
        }
        
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

    public void Keluar()
    {
        Application.Quit();
    }
}
