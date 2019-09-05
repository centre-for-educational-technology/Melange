using UnityEngine;
using System.Collections;

public class MessageButton : MonoBehaviour {

	void OnMouseDown() {
		Pad.HideAllScreens ();
		Pad.messages.SetActive (true);
		Pad.HideNotifications();
	}

	// Use this for initialization
	void Awake () {
		
	}

	// Update is called once per frame
	void Update () {

	}
}
