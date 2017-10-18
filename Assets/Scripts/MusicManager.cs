using UnityEngine;
using System.Collections;

public class MusicManager : MonoBehaviour {

	public AudioClip[] levelMusicChangeArray;
	private AudioSource audioSource;
	
	// Use this for initialization
	void Awake () {
		DontDestroyOnLoad(gameObject);
		Debug.Log("Don't destory on load: " + name);
	}
	
	/**
	 * Called on start. Finds an instances of required components. 
	 */
	void Start(){
		audioSource = GetComponent<AudioSource>();//Get component because we want part of our current game object, not the whole object
	}
	
	/**
	 * Loads selected music clip if there is a specified clip for the level. 
	 * Continues to play old audio file if there is no new source.
	 */
	void OnLevelWasLoaded(int level){
		AudioClip music = levelMusicChangeArray[level];
		
		if (music == null){ // Checks for a new 
			Debug.Log("No new music clip. Continuing old clip");
			return;
		}
		if (audioSource.audio == music) {
			Debug.Log ("Audiosource is already playing. Continuing old clip");
			return;
		}
		audioSource.Stop();
		Debug.Log("Playing clip: " + levelMusicChangeArray[level]);
		if (music){
			audioSource.Stop();
			audioSource.clip = music;
			audioSource.loop = true;
			audioSource.volume = PlayerPrefsManager.getMasterVolume();
			audioSource.Play();
		}
		
	}
	
	/**
	 * Changes music volume.
	 */
	public void changeVolume(float volume){
		audioSource.volume = volume;
	}
}
