using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

	public float health = 20f;

	/**
	 * Decreases health based on damage taken
	 * Destroys gameobject if the object has no more health.
	 */
	public void decreaseHealth(float damage){
		health -= damage;
		if (health <= 0) {
			//Optionally triger an animation
			destroyObject();
		}
	}
	
	/**
	 * Responsible for destroying the gameobject.
	 */
	public void destroyObject(){
		Destroy (gameObject);
	}
}
