using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectChapter : MonoBehaviour
{

    public string lv1, lv2, lv3;
    public Button bt1, bt2, bt3;
    public GameObject g1, g2, g3;

    // Start is called before the first frame update
    void Start()
    {
        lv1 = PlayerPrefs.GetString("firstLvl");
        lv2 = PlayerPrefs.GetString("secondLvl");
        lv3 = PlayerPrefs.GetString("thirdLvl");
        Debug.Log(lv1);
    }

    // Update is called once per frame
    void Update()
    {
        if (lv1.Equals("true"))
        {
            g1.active = false;
        }
        else
        {
            bt1.interactable = false;
        }

        if (lv2.Equals("true"))
        {
            g2.active = false;
        }
        else
        {
            bt2.interactable = false;
        }

        if (lv3.Equals("true"))
        {
            g3.active = false;
        }
        else
        {
            bt3.interactable = false;
        }
    }
}
