using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;

public class InactivityTrigger : MonoBehaviour {

	public int seconds;

	public Action action;
	public bool startTimerAtStart;
	public AudioClip audioFile;
	public string startVariable;
	public string cancelVariable;
	[ConversationPopup(true)] // Show database selection field.
	public string conversation; 


	private AudioSource audioSource;
	private bool started;

	public enum Action{
		playAudio,startConversation
	}

	private void startTimer(){
		InvokeRepeating ("Countdown", 1.0f, 1.0f);
	}

	// Use this for initialization
	void Start () {
		if (action == Action.playAudio) {
			audioSource = gameObject.AddComponent<AudioSource>();
		}
		if (startTimerAtStart) {
			InvokeRepeating ("Countdown", 1.0f, 1.0f);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (DialogueLua.GetVariable (startVariable).AsBool == true && !started) {
			started = true;
			startTimer ();
		}
	}

	void Countdown () {
		if (seconds < 2 && DialogueManager.IsConversationActive) {
			// don't advance timer
		} else {
			seconds--;
		}

		if (seconds == 0) {
			if (action == Action.startConversation && !DialogueLua.GetVariable(cancelVariable).AsBool && !DialogueManager.IsConversationActive) {
				DialogueManager.StartConversation(conversation);
			}
			if (action == Action.playAudio && !DialogueLua.GetVariable(cancelVariable).AsBool && !DialogueManager.IsConversationActive) {
				audioSource.PlayOneShot (audioFile);
			}
			CancelInvoke ("Countdown");
		}


	}
}
