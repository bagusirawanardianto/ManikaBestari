﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gameplay : MonoBehaviour {
	//public string[] soal;
	public string[] jawaban;

	public Text  text_skor;
	public InputField input_jawaban;
    public Sprite[] soal;

    public GameObject text_soal, feed_benar, feed_salah, selesai, kalah;

	int nomor_soal = -1, skor = 0;

	// Use this for initialization
	void Start () {
		buka_soal ();
        
    }

	void buka_soal(){
		nomor_soal++;
		//text_soal.text = soal [nomor_soal];
        //int index = Random.Range(0, soal.Length);
        text_soal.GetComponent<SpriteRenderer>().sprite = soal [nomor_soal];
    }

	public void jawab(){
		if (nomor_soal < soal.Length-1) {
			if (input_jawaban.text == jawaban [nomor_soal]) {
				feed_benar.SetActive (false);
				feed_benar.SetActive (true);
				feed_salah.SetActive (false);
				skor += 20;
			} else {
				feed_benar.SetActive (false);
				feed_salah.SetActive (false);
				feed_salah.SetActive (true);
			}
			buka_soal ();
			input_jawaban.text = "";
		} else {
            if (nomor_soal == soal.Length - 1)
            {
                if (skor < 80)
                {
                    kalah.SetActive(true);
                    StartCoroutine(ExampleCoroutine());
                }
                else
                {
                    selesai.SetActive(true);
                    PlayerPrefs.SetString("secondLvl", "true");
                    PlayerPrefs.Save();
                }

            }

            //transform.GetChild(transform.childCount-1).gameObject.SetActive (false);
        }
	}
	
	// Update is called once per frame
	void Update () {
		text_skor.text = skor.ToString ();
      
	}

    IEnumerator ExampleCoroutine()
    {

        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("TebakGambarGame");

    }
}
