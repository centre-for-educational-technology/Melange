using UnityEngine;
using System.Collections;

public class SettingsButton : MonoBehaviour {

	void OnMouseDown() {
		Pad.HideAllScreens ();
		Pad.settings.SetActive(true);
	}

	// Use this for initialization
	void Awake () {

	}
	
	// Update is called once per frame
	void Update () {

	}

}
