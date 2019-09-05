using UnityEngine;
using System.Collections;

public class SellAppButton : MonoBehaviour {

	void OnMouseDown() {
		Pad.HideAllScreens ();
		Pad.sellApp.SetActive(true);
	}

	// Use this for initialization
	void Awake () {

	}
	
	// Update is called once per frame
	void Update () {

	}

}
