using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour {

	public GameObject projectile, gun; // Shooters (defenders that shoot) should have a projectile type and a gun
	private GameObject projectileParent; // A folder in which to place all projectiles
	private Animator animator; // Animator responsible for moving sprite
	private Spawner myLaneSpawner; // Lane spawner in the given lane.
	
	/**
	 * Called on start. Finds an instances of required components. 
	 */
	void Start(){
		animator = GameObject.FindObjectOfType<Animator>();
		//Creates a parent object to contain all projectiles, if needed
		projectileParent = GameObject.Find ("Projectiles");
		if (!projectileParent){
			projectileParent = new GameObject("Projectiles");
		}
		setMyLaneSpawner();
	}
	
	/**
	 * Called every frame. Changes the attack state of the defender based on enemies to attack.
	 */
	void Update() {
		if (animator) {
			updateAttack();
		} else {
			Debug.LogWarning("No animator found.");
		}
		
	}

	/**
	 * Create and fire a new instance of the projectile.
	 */
	private void fire(){
		GameObject newProjectile = Instantiate(projectile) as GameObject;
		newProjectile.transform.parent = projectileParent.transform;
		newProjectile.transform.position = gun.transform.position;
	}
	
	/**
	 * Finds the enemy lane spawner in the same lane as the given shooter defender. Lane defender is used to check
	 * for enemies to attack.
	 */
	void setMyLaneSpawner() {
		//Look through all spawners and set mySpawner once we have found a spawner with the same y coord as us
		float myYPos = transform.position.y;
		Spawner[] spawners = GameObject.FindObjectsOfType<Spawner>();
		foreach (Spawner spawn in spawners) { // Finds the lane spawner associated with current lane.
			if (spawn.transform.position.y == myYPos) {
				myLaneSpawner = spawn;
				return;
			}
		} 
		Debug.LogError("Cannot find a spawner for lane " + transform.position.y);
	}
	
	/**
	 * Checks to see if there is an enemy in the lane to attack. 
	 *
	 * Returns a bool indicating enemy presence.
	 */
	bool isAttackerAheadInLane() {
		//myLaneSpawner.
		if (myLaneSpawner.transform.childCount <= 0){
			return false;
		}
		//Iterate through the children of the spawner to see if there are enemies ahead of our corrent x position
		foreach(Transform attacker in myLaneSpawner.transform){
			if (attacker.transform.position.x > transform.position.x ){
				return true;
			}
		}
		return false;
	}
	
	/**
	 * Updates attacking bool to trigger animator to change states.
	 */
	void updateAttack(){
		if (isAttackerAheadInLane()) {
			animator.SetBool("isAttacking Bool", true);
		} else{
			animator.SetBool("isAttacking Bool", false);
		}
	}

	
}
