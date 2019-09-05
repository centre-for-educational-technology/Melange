using UnityEngine;
using System.Collections;

public class PadClick : MonoBehaviour {

	void OnMouseDown() {
		UIPadButton.bigPad.SetActive(true);
	}

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {

	}
}
