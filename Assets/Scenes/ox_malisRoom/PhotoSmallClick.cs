using UnityEngine;
using System.Collections;

public class PhotoSmallClick : MonoBehaviour {

	private GameObject photo;
	
	void OnMouseDown() {
		photo.SetActive(true);
	}

	// Use this for initialization
	void Start () {
		photo = GameObject.Find ("bandfoto");
		photo.SetActive (false);
	}

	// Update is called once per frame
	void Update () {

	}
}
