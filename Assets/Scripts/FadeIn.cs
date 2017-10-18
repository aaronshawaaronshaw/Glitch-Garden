using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FadeIn : MonoBehaviour {

	public float fadeInTime;
	private Image fadePanel;

	/**
	 * Called on start. Finds an instances of required components. 
	 */
	void Start () {
		fadePanel = GameObject.Find("Fade In").GetComponent<Image>();
		fadePanel.CrossFadeAlpha(0f, fadeInTime, false);

	}
	
	/**
	 * Waits until the fadeInTime has passed and then removes the fade panel.
	 */
	void Update () {
		if (Time.timeSinceLevelLoad > fadeInTime){
			gameObject.SetActive(false);
		}
	}
	
}
