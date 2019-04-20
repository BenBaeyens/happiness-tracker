using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DevOptions : MonoBehaviour {

	public InputField noteField; // The standard note input field 
	public Text notefieldText; // The confirmation text
	public Text notefieldTextOff; // The disable confirmation text
	public GameObject devOptionsParent; // The dev-options parent

	private string password = "DevOptions";
	private string undo = "Undo";

	private bool hasAccess = false;

	private void Update() // Standard update function
	{
		if (noteField.text == password || noteField.text == undo) // Check if the password is typed, correctly
			StartCoroutine(Access());
	
	}

	IEnumerator Access()
	{
		if (!hasAccess && noteField.text == password)
		{
			hasAccess = true;
			devOptionsParent.SetActive(true); // Enable developer options.
			noteField.text = "";
			notefieldText.gameObject.SetActive(true); // Show confirm text
			yield return new WaitForSeconds(4);
			notefieldText.gameObject.SetActive(false); // Remove confirm text after 4 seconds
		}
		else if (hasAccess && noteField.text == undo)
		{
			hasAccess = false;
			devOptionsParent.SetActive(false); // Disable dev options.
			noteField.text = "";
			notefieldTextOff.gameObject.SetActive(true); // Show confirm undo text
			yield return new WaitForSeconds(4);
			notefieldTextOff.gameObject.SetActive(false); // Remove confirm undo text after 4 seconds
		}
	}

	public void ForceClose() // Gives the button access to the force close options
	{
		Application.Quit(); // Close application
		Debug.LogWarning("Application has been closed"); // For testing purposes on PC
	}
}
