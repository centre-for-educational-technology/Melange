using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;

public class BigFaceController : MonoBehaviour {
		
	public void OnConversationEnd(Transform actor) {
		closeBigHeads (actor.name);
	}

	public void OnConversationCancel(Transform actor) {
		closeBigHeads (actor.name);
	}

	void closeBigHeads(string actorName){
		if (UIPadButton.bigPad.activeSelf) {
			StartConversation.matt.SetActive (false);
			StartConversation.richard.SetActive (false);
			StartConversation.chris.SetActive (false);
			StartConversation.tariq.SetActive (false);
			StartConversation.paul.SetActive (false);
		}
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
