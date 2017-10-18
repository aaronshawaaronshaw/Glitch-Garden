using UnityEngine;
using System.Collections;

public class LoseCollider : MonoBehaviour {

	private LevelManager levelmanager;

	// Use this for initialization
	void Start () {
		levelmanager = GameObject.FindObjectOfType<LevelManager>();
	}

	/**
	 * Checks if there is a collision with the lose collider. Loads lose level on collision. 
	 */
	public void OnTriggerEnter2D() {
		print ("lose");
		levelmanager.LoadLevel("03a_Lose Screen");
	}
}
