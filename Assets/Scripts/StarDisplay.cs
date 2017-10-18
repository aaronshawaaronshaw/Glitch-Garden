using UnityEngine;
using UnityEngine.UI;
using System.Collections;


[RequireComponent (typeof(Text))]
public class StarDisplay : MonoBehaviour {

	public enum Status {SUCCESS, FAILURE};

	private Text starDisplay; // On screen text of star count.
	private int count; // Internal counter tracking number of stars available.
	private bool switcher;

	/**
	 * Called on start. Finds an instances of required components. 
	 */	
	 void Start () {
		starDisplay = GetComponent<Text>();
		starDisplay.text = "100";
		count = 100; //Initially give the user 100 stars.
		switcher = true;
	}
	
	/**
	 * Called every frame. Adds stars from the passive spawn rate.
	 */
	void Update() {
		passiveStarSpawn();
	}
	
	/**
	 * Adds stars to star count. Updates display on screen.
	 */
	public void addStars(int amount) {
		count += amount;
		starDisplay.text = count.ToString();
	}
	
	/**
	 * Tracks user's ability to use stars. If requested number of stars is not available, returns a status of FAILURE. 
	 */
	public Status useStars(int amount) {
		if (count >= amount) {
			count -= amount;
			print (count);
			starDisplay.text = count.ToString();
			return Status.SUCCESS;
		}
		return Status.FAILURE;
	}
	
	/**
	 * Passively adds stars based on time passed. 10 new stars once every 12 seconds. 
	 * Switch is to ensure stars aren't added every frame for the duration of the 12th second. (because interger division).
	 */
	private void passiveStarSpawn() {
		if ((int) Time.time % 12 == 0 && switcher && Time.time > 2) {
			addStars(10);
			switcher = false;
		}
		if ((int) Time.time % 12 != 0 & switcher == false) {
			switcher = true;
		}
	}
	
	
}
