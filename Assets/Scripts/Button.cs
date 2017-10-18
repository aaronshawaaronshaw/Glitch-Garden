using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Button : MonoBehaviour {
	public static GameObject selectedDefender;
	public GameObject defenderPrefab;
	
	private Button[] buttonArray;
	private Text costText;

	/**
	 * Called on start. Finds an instance of an animator required components.
	 */
	void Start () {
		// Gathers array of buttons. Buttons are the allowed defenders for the given level.
		buttonArray = GameObject.FindObjectsOfType<Button>();
		costText = GetComponentInChildren<Text>();
		if (!costText) 		{Debug.LogWarning (name + " has no costText");}
		
		costText.text = defenderPrefab.GetComponent<Defender>().starCost.ToString();
	}
	
	/**
	 * Visually demonstrates which button has been highlighted by the user.
	 */
	void OnMouseDown(){
		//Ensures all nonclicked buttons go black
		foreach(Button thisbutton in buttonArray) {
			thisbutton.GetComponent<SpriteRenderer>().color = Color.black;
		}
		GetComponent<SpriteRenderer>().color = Color.white;
		selectedDefender = defenderPrefab;
	}
	
}
