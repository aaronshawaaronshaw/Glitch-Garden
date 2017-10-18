using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Rigidbody2D))]
public class Attacker : MonoBehaviour {

	[Range(-1f, 1.5f)]
	public float currentSpeed; // Velocity of the attacker
	[Tooltip("Average number of appearances per second")]
	public float seenXPerSeconds; // Spawn frequency of this attacker type.
	
	private GameObject currentTarget; // Current target to try to attack.
	private Animator animator; // Animator component of the attacker. Used to physically move attacker and defines when to attack.
	
	/**
	 * Called on start. Finds an instance of an animator for the current attacker. 
	 */
	void Start () {
		//Rigidbody2D myRigidBody = gameObject.AddComponent<Rigidbody2D>();
		//myRigidBody.isKinematic = true;
		animator = GetComponent<Animator>();
		
	}
	
	/**
	 * Called once per frame. Moves attacker forward based on character's speed.
	 */
	void Update () {
		transform.Translate(Vector3.left * currentSpeed * Time.deltaTime);
		if (!currentTarget){ // If there is no target within attack range, do nothing.
			animator.SetBool("isAttacking Bool", false);
		}
		
	}
	
	/** 
	 * Sets speed to speed's value.
	 */
	void setSpeed(float speed){
		currentSpeed = speed;
	}
	
	/**
	 * Called from the animator at the time of the attacker's attack.
	 * Attempts to strike the object (defender) in front of it.
	 *
	 * Modifies: decrease's the health of the target.
	 */ 
	public void strikeCurrentTarget(float damage){
		//Debug.Log("Attacking for " + damage.ToString());
		if (currentTarget) {
			Health health = currentTarget.GetComponent<Health>() as Health;
			if (!health) {
				Debug.LogError("There is no health component associated with " + currentTarget);
				
			} else 	{health.decreaseHealth(damage);}
			
		}
		
		
	}
	
	/**
	 * Sets the target to be attacked next.
	 */
	public void attack(GameObject obj) {
		currentTarget = obj;

	}
	
}
