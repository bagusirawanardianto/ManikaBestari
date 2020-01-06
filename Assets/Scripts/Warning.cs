using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warning : MonoBehaviour
{

    public AudioClip audioClip;
    private AudioSource MPClip;

    public GameObject Warning1, Warning2;
    // Start is called before the first frame update
    void Start()
    {
        MPClip = gameObject.AddComponent<AudioSource>();
        MPClip.clip = audioClip;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void next()
    {
        Warning1.SetActive(false);

        MPClip.Play();
    }

    public void close()
    {
        Warning2.SetActive(false);

        MPClip.Play();
    }
}
