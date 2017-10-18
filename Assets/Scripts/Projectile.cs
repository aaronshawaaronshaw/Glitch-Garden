using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

	public float speed, damage;
	
	/**
	 * Called every frame. Moves the projectile based on velocity.
	 */
	void Update () {
		transform.Translate(Vector3.right * speed * Time.deltaTime);
	}
	
	/**
	 * Destroys the projectile if it leaves the play space.
	 */
	void OnBecameInvisible(){
		Destroy(gameObject);
	}
	
	/**
	 * Checks to see if the object comes in contact with defender or attacker.
	 * Ignores defends, but destroys on hit with attackers. Also causes damage to attacker.
	 */
	void OnTriggerEnter2D(Collider2D collider){
		if (collider.GetComponent<Defender>() || collider.GetComponent<Shredder>()){
			return;
		} 
		Health colliderHealth = collider.GetComponent<Health>() as Health;
		if (colliderHealth) { // If the enemy has a health component, decrement its health.
			colliderHealth.decreaseHealth(damage);
			Destroy(gameObject);
		} else {
			Debug.LogWarning("Enenmy has no Health component");
		}
		
	}
	
	
}
