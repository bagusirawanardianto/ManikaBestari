using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PuzzleGame : MonoBehaviour
{

    float countdown = 90;
    float timer = 0;
    public Text time;
    public bool gameOver = false, menang = false;

    public GameObject panelMenang, panelKalah;
    public string next;

    // Start is called before the first frame update
    void Start()
    {   
        time.text = "01:30";
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameOver || !menang)
        {
            timer += Time.deltaTime;
            if (timer > 1f)
            {
                timer = 0;
                if (countdown > 0)
                {
                    countdown--;
                    string minutes = Mathf.Floor(countdown / 60).ToString("00");
                    string seconds = Mathf.Floor(countdown % 60).ToString("00");
                    time.text = minutes + ":" + seconds;
                }
                else
                {
                    gameOver = true;
                }
            }
        }

        if (menang)
        {
            //time.text = "Congratulations";
            panelMenang.SetActive(true);
            timer = 0;
            next = "EndVideo";
            StartCoroutine(ExampleCoroutine());
        }

        if (gameOver){
            panelKalah.SetActive(true);
            time.text = "GameOver";
            timer = 0;
            next = "Chapter_3";
            StartCoroutine(ExampleCoroutine());
        }
    }

    IEnumerator ExampleCoroutine()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(next);
    }
}
