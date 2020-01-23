using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DeteksiSampah : MonoBehaviour
{
    // Start is called before the first frame update
    public string nameTag;
    public AudioClip audioBenar;
    public AudioClip audioSalah;
    public AudioClip music;
    private AudioSource MediaPlayerBenar;
    private AudioSource MediaPlayerSalah, musicMP;
    public Text textScore;
    public GameObject winPanel, munculSampah, akhir;

    void Start()
    {
        
        MediaPlayerBenar = gameObject.AddComponent<AudioSource>();
        MediaPlayerBenar.clip = audioBenar;

        MediaPlayerSalah = gameObject.AddComponent<AudioSource>();
        MediaPlayerSalah.clip = audioSalah;

        musicMP = gameObject.AddComponent<AudioSource>();
        musicMP.clip = music;
        musicMP.Play();

    }

    // Update is called once per frame
    void Update()
    {
        if(Data.score == 100)
        {
            //menang
            winPanel.active = true;
            Destroy(munculSampah);
            Destroy(akhir);
            PlayerPrefs.SetString("secondLvl", "true");
            PlayerPrefs.Save();
            //StartCoroutine(ExampleCoroutine());
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals(nameTag))
        {
            Data.score += 25;
            textScore.text = Data.score.ToString();
            Destroy(collision.gameObject);
            MediaPlayerBenar.Play();
        }
        else
        {
            Data.score -= 5;
            textScore.text = Data.score.ToString();
            Destroy(collision.gameObject);
            MediaPlayerSalah.Play();
        }
    }

        IEnumerator ExampleCoroutine()
        {

            yield return new WaitForSeconds(3);

            SceneManager.LoadScene("sampah2");
        
        }
   }
