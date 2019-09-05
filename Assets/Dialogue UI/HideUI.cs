using UnityEngine;
using System.Collections;
using PixelCrushers.DialogueSystem;

public class HideUI : MonoBehaviour {

	private GameObject ui;
	public GameObject backCollider;

	// Use this for initialization
	void Start () {
		ui = GameObject.Find ("UI");
		backCollider = GameObject.Find ("BackCollider");
		backCollider.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnConversationStart(Transform actor) {
		ui.SetActive (false);
		//backCollider.SetActive (true);
	}

	public void OnConversationEnd(Transform actor) {
		ui.SetActive (true);
		//backCollider.SetActive (false);
	}
}
