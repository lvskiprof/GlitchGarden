using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderButton : MonoBehaviour
{
	[SerializeField]
	byte greyColorValue = 100;  // Settable in the Unity Editor in case it is needed to be different for various images
	[SerializeField]
	Defender defenderPrefab;

/***
 *      Set the buttons to the greyed out value when we start.
 ***/
	void Start()
	{
		var buttons = FindObjectsOfType<DefenderButton>();
		foreach (DefenderButton button in buttons)
		{
			button.GetComponent<SpriteRenderer>().color =
				new Color32(button.greyColorValue, button.greyColorValue, button.greyColorValue, 255); // Make button image greyed out
		}   // foreach()
	}   // Start()

	private void OnMouseDown()
	{
		var buttons = FindObjectsOfType<DefenderButton>();
		foreach (DefenderButton button in buttons)
		{
			button.GetComponent<SpriteRenderer>().color =
				new Color32(button.greyColorValue, button.greyColorValue, button.greyColorValue, 255); // Make button image greyed out
		}	// foreach()

		GetComponent<SpriteRenderer>().color = Color.white; // Make button image fully visible
		FindObjectOfType<DefenderSpawner>().SetSelectedDefender(defenderPrefab);
	}   // OnMouseDown()
}   // class DefenderButton