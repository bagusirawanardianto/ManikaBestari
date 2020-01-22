using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour {

	Transform menuPanel;
	Event keyEvent;
	Text buttonText;
	KeyCode newKey;

	bool waitingForKey;

	void Start ()
	{
		menuPanel = transform.Find("PanelSettings");
		waitingForKey = false;
        
		for(int i = 0; i < menuPanel.childCount; i++)
		{
			if(menuPanel.GetChild(i).name == "ForwardKey")
				menuPanel.GetChild(i).GetComponentInChildren<Text>().text = GameManager.GM.forward.ToString();
			else if(menuPanel.GetChild(i).name == "BackwardKey")
				menuPanel.GetChild(i).GetComponentInChildren<Text>().text = GameManager.GM.backward.ToString();
			else if(menuPanel.GetChild(i).name == "JumpKey")
				menuPanel.GetChild(i).GetComponentInChildren<Text>().text = GameManager.GM.jump.ToString();
        }
	}


	void Update ()
	{
		if(Input.GetKeyDown(KeyCode.Escape) && !menuPanel.gameObject.activeSelf)
			menuPanel.gameObject.SetActive(true);
		else if(Input.GetKeyDown(KeyCode.Escape) && menuPanel.gameObject.activeSelf)
			menuPanel.gameObject.SetActive(false);
	}

	void OnGUI()
	{
		keyEvent = Event.current;
        
		if(keyEvent.isKey && waitingForKey)
		{
			newKey = keyEvent.keyCode;
			waitingForKey = false;
		}
	}
    
	public void StartAssignment(string keyName)
	{
		if(!waitingForKey)
			StartCoroutine(AssignKey(keyName));
	}
    
	public void SendText(Text text)
	{
		buttonText = text;
	}
    
	IEnumerator WaitForKey()
	{
		while(!keyEvent.isKey)
			yield return null;
	}
    
	public IEnumerator AssignKey(string keyName)
	{
		waitingForKey = true;

		yield return WaitForKey();

		switch(keyName)
		{
		case "forward":
			GameManager.GM.forward = newKey;
			buttonText.text = GameManager.GM.forward.ToString();
			PlayerPrefs.SetString("forwardKey", GameManager.GM.forward.ToString());
			break;
		case "backward":
			GameManager.GM.backward = newKey; 
			buttonText.text = GameManager.GM.backward.ToString();
			PlayerPrefs.SetString("backwardKey", GameManager.GM.backward.ToString());
			break;
		case "jump":
			GameManager.GM.jump = newKey; 
			buttonText.text = GameManager.GM.jump.ToString(); 
			PlayerPrefs.SetString("jumpKey", GameManager.GM.jump.ToString()); 
			break;
        }

		yield return null;
	}

    public void Save()
    {
        SceneManager.LoadScene("Menu");
    }
}
