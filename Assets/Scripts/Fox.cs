using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Attacker))]
public class Fox : MonoBehaviour {

	private Animator animator;
	private Attacker attacker;

	/**
	 * Called on start. Finds an instances of required components. 
	 */
	void Start () {
		animator = GetComponent<Animator>();
		attacker = GetComponent<Attacker>();
	}
	
	/**
	 * Checks to see if the fox has run into another game object. Ignores nondefender types.
	 * Attempts to jump over stones, but otherwise sets attacking bool to true.
	 * Allows for animator to handle attacking.
	 */	
	void OnTriggerEnter2D(Collider2D collider){

		GameObject obj = collider.gameObject;
		if (!obj.GetComponent<Defender>()){
			return;
		}
		//Debug.Log (name + " Trigger enter with " + collider);
		if (obj.GetComponent<Stone>()){
			//Trigger jump animation
			animator.SetTrigger("Jump Trigger");
			
		} else {
			animator.SetBool("isAttacking Bool", true);
			attacker.attack(obj);
		}

	}
		
}
