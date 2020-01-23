using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PindahScene2 : MonoBehaviour
{
    public bool isEscapeToExit;

    // Start is called before the first frame update
    void Start()
    {

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
                SettingPermainan();
            }
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

    public void MulaiPermainan()
    {
        SceneManager.LoadScene("Intro");
    }

        public void KembaliKeMenu()
    {
        SceneManager.LoadScene("Menu");
    }

       public void ControllerSetting()
    {
        SceneManager.LoadScene("Controller");
    }
}
