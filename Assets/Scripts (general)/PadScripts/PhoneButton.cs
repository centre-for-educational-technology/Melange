using UnityEngine;
using System.Collections;

public class PhoneButton : MonoBehaviour {

	void OnMouseDown() {
		Pad.HideAllScreens ();
		Pad.list.SetActive(true);
	}

	// Use this for initialization
	void Awake () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

}
