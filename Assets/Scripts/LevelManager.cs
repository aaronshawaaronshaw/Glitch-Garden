using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	public static int difficulty = 2;

	public float autoLoadNextLevelAfter; // Time to wait until loading start menu.
	
	/**
	 * Called on start. Loads first actual level after splash screen has shown for a short duration.
	 */
	void Start(){
		if(Application.loadedLevel == 0){
			Invoke ("LoadNextLevel", autoLoadNextLevelAfter);
		}
	}
	
	/**
	 * Attempt to load the level selected.
	 */
	public void LoadLevel(string name){
		Debug.Log ("New Level load: " + name);
		Application.LoadLevel (name);
	}

	/**
	 * Handles quit requests by user.
	 */
	public void QuitRequest(){
		Debug.Log ("Quit requested");
		Application.Quit ();
	}
	
	/**
	 * Attempt to load the next indexed level.
	 */
	public void LoadNextLevel(){
		Application.LoadLevel(Application.loadedLevel + 1);
	}

}
