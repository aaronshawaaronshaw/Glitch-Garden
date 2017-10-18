using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class OptionsController : MonoBehaviour {

	public Slider volumeSlider, difficultySlider; //volume = [0,1] and difficulty = {1, 2, 3}
	public LevelManager levelManager;
	
	private MusicManager musicManager;
	
	/**
	 * Called on start. Finds an instances of required components. 
	 */
	void Start () {
		if (Application.loadedLevelName == "03_Lose Screen") {
			return;
		}
		musicManager = GameObject.FindObjectOfType<MusicManager>();
		volumeSlider.value = PlayerPrefsManager.getMasterVolume();
		difficultySlider.value = PlayerPrefsManager.getDifficulty();
	}
	
	/**
	 * Called once per frame.
	 */
	 void Update () {
		//if (Application.loadedLevelName == "03a_Lose Screen") {
		//	return;
		//}
		if (volumeSlider == null) { // Error check to see if there is a volume slider.
			Debug.LogError("No volume slider found");
		}
		if (difficultySlider == null) { // Error check to see if there is a difficulty slider.
			Debug.LogWarning("No difficulty slider found");
		}
		if(musicManager){ // Changes music volume to match the value of the slider.
			musicManager.changeVolume(volumeSlider.value);
		} else{ // Logs warning that no music player exists.
			Debug.LogWarning("No Music Manger found");
		}
		
		if(difficultySlider) { // Changes difficulty level to match that of the slider.
			Spawner.difficulty = (int) difficultySlider.value;
			LevelManager.difficulty = (int) difficultySlider.value;
		} else {
			Debug.LogWarning("No difficulty slider found");
		}
	}
	
	/**
	 * Ensures the volume and difficulty are saved on exit. Calls the pref manager to adjust settings.
	 */
	public void saveAndExit(){
		PlayerPrefsManager.setMasterVolume(volumeSlider.value);
		PlayerPrefsManager.setDifficulty(difficultySlider.value);
		levelManager.LoadLevel("01a_Start Menu");
	}
	
	/**
	 * Restores the default values of half.
	 */
	public void setDefault(){
		volumeSlider.value = .5f;
		difficultySlider.value = 2f;
	}
}
