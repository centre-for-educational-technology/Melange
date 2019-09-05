using UnityEngine;
using System.Collections;

public class UIPadButton : MonoBehaviour {

	public static GameObject bigPad;

	void OnMouseDown() {
		bigPad.SetActive(true);
	}

	// Use this for initialization
	void Awake () {
		bigPad = GameObject.Find ("Pad");
		bigPad.SetActive (false);
	}

	// Update is called once per frame
	void Update () {

	}
}
