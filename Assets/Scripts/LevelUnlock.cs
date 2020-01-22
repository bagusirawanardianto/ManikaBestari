using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelUnlock : MonoBehaviour
{
    public static int level;
    public int max_level;
    public GameObject[] LevelUnlocked;

    // Start is called before the first frame update
    void Start()
    {
        level = PlayerPrefs.GetInt("level", level);
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 1; i < max_level; i++)
        {
            if (i <= level)
            {
                LevelUnlocked[i].SetActive(false);
                Debug.Log("" + level);
                } else {
                    LevelUnlocked[i].SetActive(true);
                    Debug.Log("" + level);
        }
      }
    }

    public static void NextLevel()
    {
        level += 1;
        PlayerPrefs.SetInt("level", level);
    }

    public static void Reset()
    {
        level = 1;
        PlayerPrefs.SetInt("level", level);
    }

    public static void AddLevel()
    {
        NextLevel();
        Application.LoadLevel("Chapter_1");
    }
}
