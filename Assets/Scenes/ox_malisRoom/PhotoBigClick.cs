using UnityEngine;
using System.Collections;

public class PhotoBigClick : MonoBehaviour {

	private GameObject photo;
	
	void OnMouseDown() {
		photo.SetActive(false);
	}

	// Use this for initialization
	void Start () {
		photo = GameObject.Find ("bandfoto");
	}

	// Update is called once per frame
	void Update () {

	}
}
