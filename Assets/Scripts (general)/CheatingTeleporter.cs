using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class CheatingTeleporter : MonoBehaviour {

	public string scene;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.K)) {
			SceneManager.LoadScene(scene);
		}

		// Check if any key is pressed
		if (Input.anyKeyDown) {
			if (Input.GetKey (KeyCode.B) && Input.GetKey (KeyCode.C) && Input.GetKey (KeyCode.N)) {
				SceneManager.LoadScene ("bcn_airport");
			} else if (Input.GetKey (KeyCode.L) && Input.GetKey (KeyCode.U) && Input.GetKey (KeyCode.X)) {
				SceneManager.LoadScene ("lux_info");
			} else if (Input.GetKey (KeyCode.F) && Input.GetKey (KeyCode.R) ) {
				SceneManager.LoadScene ("fra_station");
			} else if (Input.GetKey (KeyCode.T) && Input.GetKey (KeyCode.L) && Input.GetKey (KeyCode.U)) {
				SceneManager.LoadScene ("tll_airport");
			} else if (Input.GetKey (KeyCode.O) && Input.GetKey (KeyCode.X) && Input.GetKey (KeyCode.F)) {
				SceneManager.LoadScene ("ox_malisRoom_after");
			} else if (Input.GetKey (KeyCode.I) && Input.GetKey (KeyCode.S) && Input.GetKey (KeyCode.T) ) {
				SceneManager.LoadScene ("ist_airport");
			}
		};
	}
}
