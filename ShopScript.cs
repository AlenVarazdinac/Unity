using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ShopScript : MonoBehaviour 
{
	public Image shop;
	private bool shopOpened = false;

	void Start () 
	{
	
	}
	
	void Update () 
	{
		// Open / Close shop window
		if (Input.GetKeyDown (KeyCode.E) && shopOpened == false) {
			shop.enabled = true;
			shopOpened = true;
			Debug.Log ("Shop is opened");
		} 
		else if (Input.GetKeyDown (KeyCode.E) && shopOpened == true) 
		{
			shop.enabled = false;
			shopOpened = false;
			Debug.Log ("Shop is closed");
		}

	}
}
