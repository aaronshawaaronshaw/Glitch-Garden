using UnityEngine;
using System.Collections;

public class DefenderSpawner : MonoBehaviour {
	
	public Camera myCamera;
	private GameObject parent;
	private StarDisplay starDisplay;
	
	/**
	 * Called on start. Finds an instance of required components.
	 */
	void Start () {
		starDisplay = GameObject.FindObjectOfType<StarDisplay>();
		parent = GameObject.Find ("Defenders"); // Attempts to find a Defender GameObject in which to place instances of defenders.
		if (!parent){ // parent used as a folder to organize defenders.
			parent = new GameObject("Defenders");
		}
	}
	
	/**
	 * Attempts to spawn a new defender of the selected type. 
	 *
	 * Modifies: Adds a new defender on screen if (x,y) position is available and if there is enough $$.
	 */
	void OnMouseDown() {
		//Idenfity the seltected defender
		GameObject defender = Button.selectedDefender;
		int defenderCost = defender.GetComponent<Defender>().starCost;
		
		//If we have enough currency to spawn the selected defender, instantiate the defender at the mouse location
		if (starDisplay.useStars(defenderCost) == StarDisplay.Status.SUCCESS) {
		
			Vector2 position = calculateWorldPoint();
			defender = Instantiate(Button.selectedDefender, position, Quaternion.identity) as GameObject;
			defender.transform.parent = parent.transform;
		} else {
			Debug.Log("Insufficient stars to spawn");
		}

	}
	
	/**
	 * Calculates the world point (x,y) ints based off of current mouse location. Rounds to ensure int tuple.
	 *
	 * Returns: world point location as a Vector2
	 */
	Vector2 calculateWorldPoint() {
		float distanceFromCamera = 10f;
		Vector2 location = Input.mousePosition;
		Vector3 triple = new Vector3(location.x, location.y, distanceFromCamera);
		return snapToGrid(myCamera.ScreenToWorldPoint(triple));	
	}
	
	/**
	 * Ensures the given Vector2 is rounded properly to grid format.
	 */
	Vector2 snapToGrid(Vector2 position) {
		return new Vector2(Mathf.RoundToInt(position.x), Mathf.RoundToInt(position.y));
	}

}
