using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Attacker))]
public class Lizard : MonoBehaviour {
	
	private Animator animator;
	private Attacker attacker;
	
	/**
	 * Called on start. Finds an instances of required components. 
	 */	void Start () {
		animator = GetComponent<Animator>();
		attacker = GetComponent<Attacker>();
	}

	/**
	 * Checks what gameobject the lizard collided with. Ignores collisions with other attackers.
	 * Sets attack bool to true, but lets animator handle attacking the defender.
	 */
	void OnTriggerEnter2D(Collider2D collider){
		
		GameObject obj = collider.gameObject;
		if (!obj.GetComponent<Defender>()){
			return;
		}		
		animator.SetBool("isAttacking Bool", true);
		attacker.attack(obj);
		
		
	}
	
	
	
	
	
	
	
}
