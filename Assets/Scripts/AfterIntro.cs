using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AfterIntro : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ExampleCoroutine());

        PlayerPrefs.SetString("isPlayed", "true");
        PlayerPrefs.SetString("firstLvl", "true");
        PlayerPrefs.Save();
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator ExampleCoroutine()
    {

        yield return new WaitForSeconds(27);
        SceneManager.LoadScene("Chapter_1");

    }
}
