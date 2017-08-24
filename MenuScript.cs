using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour 
{
	// Start
	public Image startImage;
	private bool startOn = false;

	// Options
	public Image optionsImage;
	private bool optionsOn = false;

	// Credits
	public Image creditsImage;
	private bool creditsOn = false;
	
	void Start () 
	{
		// Hides start, options and credits window
		startImage.enabled = false;
		optionsImage.enabled = false;
		creditsImage.enabled = false;
	}

	void Update () 
	{

	}

	// Handle start button
	public void StartBtn()
	{
		if (startOn == false) 
		{
			startImage.enabled = true;
			startOn = true;
			Debug.Log ("Start Opened");
		}
		else if (startOn == true) 
		{
			startImage.enabled = false;
			startOn = false;
			Debug.Log("Start Closed");
			
		}
	}

	// Handle options button
	public void OptionsBtn()
	{
		if (optionsOn == false) 
		{
			optionsImage.enabled = true;
			optionsOn = true; 
			Debug.Log("Options opened");
		} 
		else if (optionsOn == true) 
		{
			optionsImage.enabled = false;
			optionsOn = false;
			Debug.Log("Options closed");
		}
	}

	// Handle credits button
	public void CreditsBtn()
	{
		if (creditsOn == false) {
			creditsImage.enabled = true;
			creditsOn = true;
			Debug.Log ("Credits opened");
		} 
		else if (creditsOn == true) 
		{
			creditsImage.enabled = false;
			creditsOn = false;
			Debug.Log("Credits closed");
		}
	}

	// Handle exit button
	public void ExitBtn()
	{
		Application.Quit ();
		Debug.Log("Application has ended");
	}

	// Changing scene
	public void ChangeToScene (string sceneToChangeTo)
	{
		// Used in old version
		//Application.LoadLevel (sceneToChangeTo);
		ChangeToScene (sceneToChangeTo);
	}

}
