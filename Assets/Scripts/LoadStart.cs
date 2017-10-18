using UnityEngine;
using System.Collections;

public class LoadStart : MonoBehaviour {


	LevelManager levelManager;
	// Use this for initialization
	void Start () {
		levelManager = GameObject.FindObjectOfType<LevelManager>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time > 4.5f){Application.LoadLevel("Start Menu");}
	}
}
