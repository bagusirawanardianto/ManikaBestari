using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleCheck : MonoBehaviour
{
    public GameObject senyum;
    public bool selesai = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void cek()
    {
        for (int i = 0; i < 9; i++)
        {
            if (transform.GetChild(i).GetComponent<DragPuzzle>().on_tempel)
            {
                selesai = true;
            }
            else
            {
                selesai = false;
                i = 9;
            }
        }
        if (selesai)
        {
            senyum.SetActive(true);
            GetComponent<PuzzleGame>().menang = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!selesai)
        {
            cek();
        }
    }
}
