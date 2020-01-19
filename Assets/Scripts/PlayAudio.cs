using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayAudio : MonoBehaviour
{
    public AudioSource lagu1, lagu2, touch;
    public Slider Volume_music, Volume_effect;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnMouseDown(){
        touch.Play ();
        touch.volume = Volume_effect.value;

        if (gameObject.name == "tombol lagu 1"){
            lagu1.Play ();
            lagu2.Stop ();
            lagu1.volume = Volume_music.value;

        }else {
            lagu1.Stop ();
            lagu2.Play ();
            lagu2.volume = Volume_music.value;

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
