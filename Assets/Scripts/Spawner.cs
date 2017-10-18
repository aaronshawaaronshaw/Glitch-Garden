using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

	public GameObject[] enemyPrefabs;
	static public int difficulty;
	
	/**
	 * Called on start. Finds an instances of required components. 
	 */
	void Start () {
		difficulty = LevelManager.difficulty;
	}
	
	/**
	 * Called every frame. Checks whether it is time to spawn a new attacker, and spawns if true
	 */
	void Update () {
		foreach (GameObject thisAttacker in enemyPrefabs) { // Checks if each enemy type wants to spawn a new enemy. 
			if (isTimeToSpawn(thisAttacker)) { // Spawns enemy if true (different attackers have different spawn rates).
				spawnEnemy(thisAttacker);
			}
		}
	}
	
	/**
	 * Instantiates a new attacker. Gives it the position of the spawner
	 */
	void spawnEnemy(GameObject attackerToSpawn){
		GameObject newEnemy = Instantiate(attackerToSpawn) as GameObject;
		newEnemy.transform.parent = transform;
		newEnemy.transform.position = transform.position;
	}
	
	/**
	 * Determines if it is time to spawn a new attacker. Gens a random number and normalizes.
	 * If Time since the last enemy spawned is greater than the (standarized) random number, spawn a new enemy.
	 */	
	 bool isTimeToSpawn(GameObject attacker) {
		float spawnsPerSec = manageSpawnRate(attacker); // Number of attackers seen per second.
		float meanDelay = 1 / spawnsPerSec; //???
		if (Time.deltaTime > meanDelay) {
			Debug.LogWarning("Spawn rate capped by frame rate");
		}
		float threshold = spawnsPerSec * Time.deltaTime; // Normalizes it to ~1.
		
		return (Random.value < threshold / 5); // Returns true whether the randomly gen'ed number is < spawn value.
	}
	
	/**
	 * Adjusts the spawn rates based off of time since the level loaded and the difficulty level
	 * Prevents enemies from spawning in the first 20 seconds of game. Spawn rate is dependent upon
	 * overall time passed during the level. The spawn rate increases linearly over time.
	 */
	private float manageSpawnRate(GameObject attacker) {
		if (Time.timeSinceLevelLoad < 20) {
			return 0f;
		}
		float spawnRate = Time.timeSinceLevelLoad * .02f * difficulty * attacker.GetComponent<Attacker>().seenXPerSeconds;
		print (spawnRate);
		
		return spawnRate;
	}

	
}
