using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleReset : MonoBehaviour
{
    public GameObject parent_puzzle, senyum;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnMouseUp()
    {

        for (int i = 0; i < 9; i++)
        {
            parent_puzzle.transform.GetChild(i).GetComponent<DragPuzzle>().on_tempel = false;
            parent_puzzle.transform.GetChild(i).GetComponent<DragPuzzle>().on_pos = false;
            parent_puzzle.transform.GetChild(i).position = parent_puzzle.transform.GetChild(i).GetComponent<DragPuzzle>().pos_awal;
            parent_puzzle.transform.GetChild(i).position = parent_puzzle.transform.GetChild(i).GetComponent<DragPuzzle>().scale_awal;
        }

        senyum.SetActive(false);
        parent_puzzle.GetComponent<PuzzleCheck>().selesai = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
