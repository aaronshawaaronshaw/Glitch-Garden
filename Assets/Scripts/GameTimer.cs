using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameTimer : MonoBehaviour {

	public int maxLevelTime = 120;
	
	private Slider slider; // Slider to visually represent amount of time left.
	private LevelManager levelManager;
	private AudioSource audioSource; // Audio source for passing level
	private GameObject winLabel; // Text notifying user of successfully beating the level.
	private bool levelOver;
	
	/**
	 * Called on start. Finds an instances of required components. 
	 */
	void Start () {
		slider = GetComponent<Slider>();
		//slider = gameObject.GetComponent(Slider) as Slider; // Pontential other method to find slider (?)
		levelManager = GameTimer.FindObjectOfType<LevelManager>();
		audioSource = GetComponent<AudioSource>();
		findYouWin();
		winLabel.SetActive(false);
	}
	
	/**
	 * Updates the position of the slider every frame based off of time left in the level.
	 * Checks for end of level condition, and notfies user if the level ends.
	 */
	void Update () {
		moveSlider();
		if (slider.value >= 1 && !levelOver) {
			levelOver = true;
			audioSource.Play();
			winLabel.SetActive(true);
			Invoke("loadNextLevel", audioSource.clip.length);
		}
	}
	
	/**
	 * Recalculates slider's position based off of time passed.
	 */
	void moveSlider() {
		slider.value = Time.timeSinceLevelLoad / maxLevelTime;
	}
	
	/**
	 * Loads next level.
	 */
	void loadNextLevel() {
		levelManager.LoadNextLevel();
	}
	
	/**
	 * Finds the winLabel. Method made to preserve cleanness of Start() method.
	 */
	void findYouWin() {
		winLabel = GameObject.Find("You Win");
		if (!winLabel) {
			Debug.LogWarning("No 'You Win' Object");
		}
	}	
	
}
