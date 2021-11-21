using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{
	Defender defender;
	int defenderNumber = 0;

	/***
	*		This sets the type of Defender to instantiate, based one the currently selected button.
	***/
	public void SetSelectedDefender(Defender defenderToSpawn)
	{
		defender = defenderToSpawn;
	}   // SetSelectedDefender()

	/***
	*		When mouse click is detected place a new defender at that location.
	*	The location must have a collider attached to it.
	***/
	private void OnMouseDown()
	{
		//Debug.Log("Mouse was clicked in DefenderSpawner.");
		if (defender)
			SpawnDefender(GetSquareClicked());	// Only spawn once defender prefab has been set
	}   // OnMouseDown()

	/***
	*		This will return the position of the mouse click in World Units.
	***/
	private Vector2 GetSquareClicked()
	{
		Vector2 clickPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
		Vector2 worldPos = Camera.main.ScreenToWorldPoint(clickPos);
		worldPos.x = Mathf.Clamp(Mathf.RoundToInt(worldPos.x), 1.0f, 7.0f);	// Always ensure it is in the middle of the square left to right
		worldPos.y = Mathf.Clamp(Mathf.RoundToInt(worldPos.y), 1.0f, 5.0f); // Always ensure it is in the middle of the square up to down
		return worldPos;
	}   // GetSquareClicked()

	/***
	*		This will spawn a defender at the position the user clicked the left mouse button.
	***/
	private void SpawnDefender(Vector2 worldPos)
	{
		Defender newDefender = Instantiate(defender, worldPos, Quaternion.identity) as Defender;
		newDefender.name = newDefender.name + " #" + defenderNumber++;
		Debug.Log("Spawning " + newDefender.name + " @ " + worldPos.x + "," + worldPos.y);
	}	// SpawnDefender()
}	// class DefenderSpawner