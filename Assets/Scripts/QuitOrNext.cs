using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitOrNext : MonoBehaviour
{

	private void Update()
	{
	    if (Input.GetKeyUp(KeyCode.Escape))
	    {
	        Application.Quit();
	    }
	}
	    
	private void OnTriggerEnter2D(Collider2D collision)
	{
	    if (collision.tag.Equals("Lady"))
	    {

            if(Coins.scene == 3)
            {
                SceneManager.LoadScene("Congratulations");
            }
            else
            {
                SceneManager.LoadScene("LevelComplete");
            }

	    }
	}

}
