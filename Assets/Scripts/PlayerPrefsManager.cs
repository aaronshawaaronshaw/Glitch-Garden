using UnityEngine;
using System.Collections;

public class PlayerPrefsManager : MonoBehaviour {

	/*
	 * Acts as a wrapper to PlayerPrefs so that developers cannot randomly generate keys.
	 */

	const string MASTER_VOLUME_KEY = "master_volume"; // Master volume of the entire game.
	const string DIFFICULT_KEY = "difficulty"; // Difficulty level for the game.
	const string LEVEL_KEY = "level_unlocked_";

	/**
	 * Updates and saves the volume in PlayerPrefs.
	 */
	public static void setMasterVolume(float volume){
		if (volume >= 0f && volume <= 1f){
		PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, volume);
		} else{
			Debug.LogError("Master Volume Out of range");
		}
	}
	
	/**
	 * Returns the current volume.
	 */
	public static float getMasterVolume(){
		return PlayerPrefs.GetFloat(MASTER_VOLUME_KEY);
	}
	
	/**
	 * Returns level to be unlocked (?) 
	 */
	public static void unlockLevel(int level){
		if (level <= Application.levelCount - 1){
			PlayerPrefs.SetInt(LEVEL_KEY + level.ToString(), 1); //use 1 for true
		} else{
			Debug.LogError("Trying to unlock level not in build order");
		}
	}
	
	/**
	 * Returns a bool telling whether the current level has been unlocked yet.
	 */
	public static bool isLevelUnlocked(int level){
		if (level <= Application.levelCount - 1){
			if (PlayerPrefs.GetInt(LEVEL_KEY + level.ToString()) == 1)	{return true;} 
		} else{
			Debug.LogError("Trying to query level not in build order");
		}
		return false;
	}
	
	/**
	 * Updates and save the difficulty level in PlayerPrefs.
	 */
	public static void setDifficulty(float difficulty){
		if (difficulty >= 1f && difficulty <= 3f){
			PlayerPrefs.SetFloat(DIFFICULT_KEY, difficulty);
		} else{
			Debug.LogError("Difficulty Out of range");
		}
	}
	
	/**
	 * Returns difficulty level.
	 */
	public static float getDifficulty(){
		return PlayerPrefs.GetFloat(DIFFICULT_KEY);
	}
	
}
